using System.IdentityModel.Tokens.Jwt;

namespace EShop.Authentication;

public interface IJwtProvider
{
    (string token, int ExpiryMinutes) GenerateToken(User user, IEnumerable<string> roles, IEnumerable<string> permissions);
    JwtSecurityToken? DecodeToken(string Token);
    Guid? GetUserId(string token);
}
