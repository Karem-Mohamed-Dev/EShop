namespace EShop.Contracts.Auth;

public record RevokeRequest(string AccessToken, string RefreshToken);