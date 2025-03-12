using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace EShop.Authentication;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public (string token, int ExpiryMinutes) GenerateToken(User user, IEnumerable<string> roles, IEnumerable<string> permissions)
    {
        Claim[] claims = [
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new("roles", JsonSerializer.Serialize(roles), JsonClaimValueTypes.JsonArray),
            new("permissions", JsonSerializer.Serialize(permissions), JsonClaimValueTypes.JsonArray)
        ];

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_options.Key));

        SigningCredentials creds = new(securityKey, SecurityAlgorithms.HmacSha256);

        DateTime expiry = DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes);
        JwtSecurityToken securityToken = new(_options.Issuer, _options.Audience, claims, expires: expiry, signingCredentials: creds);
        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return (token, _options.ExpiryMinutes);
    }

    public JwtSecurityToken? DecodeToken(string Token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

        try
        {
            tokenHandler.ValidateToken(Token, new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken;
        }
        catch
        {
            return null;
        }
    }

    public Guid? GetUserId(string token)
    {
        JwtSecurityToken? decodedToken = DecodeToken(token);

        if(decodedToken == null)
            return null;

        string? extractedId = decodedToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (extractedId == null)
            return null;

        if (!Guid.TryParse(extractedId, out Guid userId))
            return null;

        return userId;
    }
}
