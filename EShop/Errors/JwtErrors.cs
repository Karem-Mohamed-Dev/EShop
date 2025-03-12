namespace EShop.Errors;

public class JwtErrors
{
    public static Error InvalidAccessToken => new("Token.InvalidAccessToken", "The provided access token is invalid", StatusCodes.Status400BadRequest);
    public static Error InvalidRefreshToken => new("Token.InvalidRefreshToken", "The provided refresh token is invalid", StatusCodes.Status400BadRequest);
    public static Error InvalidUserId => new("Token.InvalidUserId", "The user id in token is invalid", StatusCodes.Status400BadRequest);
    public static Error DoubleRevoke => new("Token.DoubleRevoke", "This refresh token had been already revoked", StatusCodes.Status400BadRequest);
}
