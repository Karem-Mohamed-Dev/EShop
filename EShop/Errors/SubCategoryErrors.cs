namespace EShop.Errors;

public class SubCategoryErrors
{
    public static Error DuplicateSubCategory => new("SubCategory.DuplicateCategory", "This SubCategory is already exists", StatusCodes.Status400BadRequest);
    public static Error NotFound => new("SubCategory.NotFound", "No SubCategory was found", StatusCodes.Status404NotFound);
}
