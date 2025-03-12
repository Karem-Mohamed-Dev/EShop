namespace EShop.Errors;

public class UserErrors
{
    public static Error InvalidCredintials => new("User.InvalidCredintials", "Invalid Email/Password.", StatusCodes.Status400BadRequest);
    public static Error NotFound => new("User.NotFound", "Cannot find user with that email.", StatusCodes.Status404NotFound);
    public static Error EmailNotComfirmed => new("User.EmailNotComfirmed", "You need to confirm your email first.", StatusCodes.Status400BadRequest);
    public static Error DoubleEmailConfirmation => new("User.DoubleEmailConfirmation", "Your email is already confirmed.", StatusCodes.Status400BadRequest);
    public static Error EmailExist => new("User.EmailExist", "This email is already in use.", StatusCodes.Status400BadRequest);
    public static Error LockedOut => new("User.LockedOut", "Too many wrong password try again later", StatusCodes.Status400BadRequest);
    public static Error Disabled => new("User.Disabled", "Your account was disabled please contact support.", StatusCodes.Status400BadRequest);
    public static Error InvalidCode => new("User.InvalidCode", "You had sent invalid confirmation code", StatusCodes.Status400BadRequest);
}
