namespace EShop.Contracts.Role;

public class UserRoleRequestValidator : AbstractValidator<UserRoleRequest>
{
    public UserRoleRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .Must(x => Guid.TryParse(x, out _))
            .WithMessage("Invalid UserId format.");
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .Must(x => Guid.TryParse(x, out _))
            .WithMessage("Invalid RoleId format.");
    }
}
