using Mapster;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;

namespace EShop.Services;

public class AuthService(
    UserManager<User> userManager
    , AppDbContext context
    , SignInManager<User> signInManager
    , IJwtProvider jwtProvider
    , IEmailService emailSender
    , IHttpContextAccessor httpContextAccessor
    , ILogger<AuthService> logger) : IAuthService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly AppDbContext _context = context;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IEmailService _emailSender = emailSender;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly ILogger<AuthService> _logger = logger;

    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Failure<LoginResponse>(UserErrors.NotFound);

        if (user.IsDisabled)
            return Result.Failure<LoginResponse>(UserErrors.Disabled);


        var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);


        if (result.Succeeded)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var permissions = await _context.Roles
                .Join(_context.RoleClaims, x => x.Id, x => x.RoleId, (role, claim) => new { role, claim })
                .Where(x => userRoles.Contains(x.role.Name!))
                .Select(x => x.claim.ClaimValue!)
                .Distinct()
                .ToListAsync(cancellationToken);

            var (token, expiryMinutes) = _jwtProvider.GenerateToken(user, userRoles, permissions);
            RefreshToken refreshToken = new()
            {
                Token = GenerateRefreshToken(),
                UserId = user.Id,
                CreatedByIp = GetIp()
            };
            await _context.AddAsync(refreshToken, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);


            return Result.Success(new LoginResponse(token, expiryMinutes, refreshToken.Token));
        }

        if (result.IsNotAllowed)
            return Result.Failure<LoginResponse>(UserErrors.EmailNotComfirmed);

        if (result.IsLockedOut)
            return Result.Failure<LoginResponse>(UserErrors.LockedOut);
        return Result.Failure<LoginResponse>(UserErrors.InvalidCredintials);
    }
    public async Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == request.Email, cancellationToken))
            return Result.Failure(UserErrors.EmailExist);

        var user = request.Adapt<User>();
        var result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            _logger.LogInformation("Code: {code}", code);
            _logger.LogInformation("UserId: {id}", user.Id);

            await SendEmailConfirmMail(user, code);

            return Result.Success();
        }

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
    public async Task<Result> ConfirmEmail(ConfirmEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByIdAsync(request.UserId) is not { } user)
            return Result.Failure(UserErrors.NotFound);

        if (user.EmailConfirmed)
            return Result.Failure(UserErrors.DoubleEmailConfirmation);

        var code = request.Code;
        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

        }
        catch (FormatException)
        {
            return Result.Failure(UserErrors.InvalidCode);
        }

        var result = await _userManager.ConfirmEmailAsync(user, code);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, DefaultRoles.Client.Name);

            await _context.AddAsync(new Cart { UserId = user.Id }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
    public async Task<Result> ResendConfirmEmailCode(ResendConfirmEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Failure(UserErrors.NotFound);

        if (user.EmailConfirmed)
            return Result.Failure(UserErrors.DoubleEmailConfirmation);

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        _logger.LogInformation("Code: {code}", code);
        _logger.LogInformation("UserId: {id}", user.Id);

        await SendEmailConfirmMail(user, code);

        return Result.Success();
    }
    public async Task<Result> ForgetPassword(ForgetPasswordRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Failure(UserErrors.NotFound);

        if (user.IsDisabled)
            return Result.Failure(UserErrors.Disabled);

        if (user.LockoutEnd is not null)
            return Result.Failure(UserErrors.LockedOut);

        if (!user.EmailConfirmed)
            return Result.Failure(UserErrors.EmailNotComfirmed);

        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        await SendPasswordResetMail(user, code);

        _logger.LogInformation("Code: {code}", code);
        _logger.LogInformation("userId: {email}", user.Id);
        return Result.Success();
    }
    public async Task<Result> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByIdAsync(request.UserId) is not { } user)
            return Result.Failure(UserErrors.NotFound);

        IdentityResult result;
        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
            result = await _userManager.ResetPasswordAsync(user, code, request.Password);
        }
        catch (FormatException)
        {
            result = IdentityResult.Failed(_userManager.ErrorDescriber.InvalidToken());
        }

        if (result.Succeeded)
        {
            var refreshTokens = await _context.RefreshTokens.Where(x => x.ExpiresAt > DateTime.Now && x.UserId == user.Id && x.RevokedAt == null).ToListAsync(cancellationToken);

            if (refreshTokens.Count > 0 && request.LogoutAllDevices)
            {
                foreach (var refreshToken in refreshTokens)
                {
                    refreshToken.RevokedAt = DateTime.UtcNow;
                    refreshToken.RevokedByIp = GetIp();
                }
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Result.Success();
        }

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
    public async Task<Result<RefreshAccessTokenResponse>> RefreshAccessToken(RefreshAccessTokenRequest request, CancellationToken cancellationToken = default)
    {
        // Get UserId by decoding the access token and get the id from claims and if any thing gose wrong it will return null
        Guid? userId = _jwtProvider.GetUserId(request.AccessToken);
        if (userId is null)
            return Result.Failure<RefreshAccessTokenResponse>(JwtErrors.InvalidAccessToken);

        // Get user by the extracted it from token and check if the user do exist or the token had been minpulated
        var user = await _userManager.FindByIdAsync(userId.ToString()!);
        if (user == null)
            return Result.Failure<RefreshAccessTokenResponse>(UserErrors.NotFound);

        // Get the old refresh token and check if it do exist
        RefreshToken? oldRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == request.RefreshToken && x.UserId == user.Id && x.CreatedByIp == GetIp(), cancellationToken);
        if (oldRefreshToken == null || !oldRefreshToken.IsActive)
            return Result.Failure<RefreshAccessTokenResponse>(JwtErrors.InvalidRefreshToken);

        var userRoles = await _userManager.GetRolesAsync(user);
        var permissions = await _context.Roles
                .Join(_context.RoleClaims, x => x.Id, x => x.RoleId, (role, claim) => new { role, claim })
                .Where(x => userRoles.Contains(x.role.Name!))
                .Select(x => x.claim.ClaimValue!)
                .Distinct()
                .ToListAsync(cancellationToken);

        // Generate new access token
        (string token, int expiryMinuts) = _jwtProvider.GenerateToken(user, userRoles, permissions);

        return Result.Success(new RefreshAccessTokenResponse(token, expiryMinuts));
    }
    public async Task<Result> RevokeRefreshToken(RevokeRequest request, CancellationToken cancellationToken = default)
    {
        // Get UserId by decoding the access token and get the id from claims and if any thing gose wrong it will return null
        Guid? userId = _jwtProvider.GetUserId(request.AccessToken);
        if (userId is null)
            return Result.Failure<RefreshAccessTokenResponse>(JwtErrors.InvalidAccessToken);

        var oldRefreshToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(x => x.Token == request.RefreshToken && x.UserId == userId && x.CreatedByIp == GetIp(), cancellationToken);

        if (oldRefreshToken == null || !oldRefreshToken.IsActive)
            return Result.Failure(JwtErrors.InvalidRefreshToken);

        oldRefreshToken.RevokedAt = DateTime.UtcNow;
        oldRefreshToken.RevokedByIp = GetIp();

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    public string GenerateRefreshToken() =>
        Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    public string GetIp() =>
        _httpContextAccessor.HttpContext!.Connection.RemoteIpAddress!.ToString();
    private async Task SendEmailConfirmMail(User user, string code)
    {
        string origin = _httpContextAccessor.HttpContext!.Request.Headers.Origin!;

        var model = new Dictionary<string, string>
        {
            { "{{url}}", $"{origin}/api/auth/confirm-email?userid={user.Id}&code={code}" }
        };

        await _emailSender.SendEmailAsync(user.Email!, "subject", "EmailConfirmation", model);
    }
    private async Task SendPasswordResetMail(User user, string code)
    {
        string origin = _httpContextAccessor.HttpContext!.Request.Headers.Origin!;

        var model = new Dictionary<string, string>
        {
            { "{{url}}", $"{origin}/api/auth/password-reset?userid={user.Id}&code={code}" }
        };

        await _emailSender.SendEmailAsync(user.Email!, "subject", "ResetPassword", model);
    }
}