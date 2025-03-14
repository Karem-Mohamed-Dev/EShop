namespace EShop.Contracts.Role;

public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
    public RoleRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Permissions)
            .Must(x => x.Any())
            .WithMessage("You Can't add role without permissions")
            .Must(x => x.Distinct().Count() == x.Count())
            .WithMessage("You cannot add doublicated permissions")
            .When(x => x.Permissions != null);
    }
}
