namespace EShop.Contracts.Auth;

public record ConfirmEmailRequest(string UserId, string Code);