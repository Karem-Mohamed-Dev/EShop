namespace EShop.Contracts.Auth;

public record LoginResponse(string AccessToken, int ExpiryMinutes, string RefreshToken);