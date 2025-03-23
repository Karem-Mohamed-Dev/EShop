namespace EShop.Errors;

public class ProductErrors
{
    public static Error NotFound => new("ProductErrors.NotFound", "No product was found", StatusCodes.Status404NotFound);
    public static Error NotAllowed => new("ProductErrors.NotAllowed", "You are not the publisher of this product", StatusCodes.Status404NotFound);
}
