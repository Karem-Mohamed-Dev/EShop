namespace EShop.Contracts.Auth;

public record RefreshAccessTokenRequest(string AccessToken, string RefreshToken);