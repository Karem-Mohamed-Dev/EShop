namespace EShop.Errors;

public static class CategoryErrors
{
    public static Error DuplicateCategory => new ("Category.DuplicateCategory", "This category is already exists", StatusCodes.Status400BadRequest);
    public static Error NotFound => new("Category.NotFound", "No category was found", StatusCodes.Status404NotFound);
}
