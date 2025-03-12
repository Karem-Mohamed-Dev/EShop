namespace EShop.Services;

public interface IAuthService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<Result> ConfirmEmail(ConfirmEmailRequest request, CancellationToken cancellationToken = default);
    Task<Result> ResendConfirmEmailCode(ResendConfirmEmailRequest request, CancellationToken cancellationToken = default);
    Task<Result> ForgetPassword(ForgetPasswordRequest request, CancellationToken cancellationToken = default);
    Task<Result> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken = default);
    Task<Result<RefreshAccessTokenResponse>> RefreshAccessToken(RefreshAccessTokenRequest request, CancellationToken cancellationToken = default);
    Task<Result> RevokeRefreshToken(RevokeRequest request, CancellationToken cancellationToken = default);
}
