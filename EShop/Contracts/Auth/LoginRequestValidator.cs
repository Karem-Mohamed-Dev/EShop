namespace EShop.Contracts.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().Matches(RegexPatterns.Email); ;
        RuleFor(x => x.Password).NotEmpty().Matches(RegexPatterns.Password);
    }
}
