namespace EShop.Contracts.Product;

public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(x => x.Price).NotNull().Must(x => x > 0);

        RuleFor(x => x.Stock).NotNull().Must(x => x > 0);

        RuleFor(x => x.DiscountPercentage)
            .Must(x => x >= 0 && x <= 100);
    }
}
