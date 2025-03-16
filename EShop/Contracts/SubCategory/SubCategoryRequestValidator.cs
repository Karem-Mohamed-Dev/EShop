namespace EShop.Contracts.SubCategory;

public class SubCategoryRequestValidator : AbstractValidator<SubCategoryRequest>
{
    public SubCategoryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}
