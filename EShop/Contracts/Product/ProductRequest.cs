namespace EShop.Contracts.Product;

public record ProductRequest
(
    string Title,
    string Description,
    int Stock,
    double Price,
    decimal DiscountPercentage,
    string CoverImage,
    IEnumerable<string> Images,
    Guid? CategoryId,
    Guid? SubCategoryId
);