namespace EShop.Contracts.Auth;

public record RefreshAccessTokenResponse(string AccessToken, int ExpiryMinutes);