namespace EShop.Contracts.Product;

public record ProductDetailsResponse
(
    Guid Id,
    SellerResponse Seller,
    string Title,
    string Description,
    double Price,
    int Stock,
    decimal DiscountPercentage,
    decimal Rate,
    string CoverImage,
    IEnumerable<string> Images,
    string? Category,
    string? SubCategory,
    DateTime CreatedAt
);