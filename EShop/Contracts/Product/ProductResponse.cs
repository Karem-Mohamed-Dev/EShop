namespace EShop.Contracts.Product;

public record ProductResponse
(
    Guid Id,
    SellerResponse Seller,
    string Title,
    double Price,
    decimal DiscountPercentage,
    decimal Rate,
    string CoverImage
);