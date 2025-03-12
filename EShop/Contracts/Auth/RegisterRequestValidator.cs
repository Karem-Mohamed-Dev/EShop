namespace EShop.Contracts.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().Matches(RegexPatterns.Email);
        RuleFor(x => x.Password).NotEmpty().Matches(RegexPatterns.Password);
    }
}
