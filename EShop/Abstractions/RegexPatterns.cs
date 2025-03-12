namespace EShop.Abstractions;

public static class RegexPatterns
{
    public const string Password = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,16}";
    public const string Email = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
}
