namespace EShop.Contracts.Auth;

public record ResetPasswordRequest(string UserId, string Code, string Password, bool LogoutAllDevices = false);