namespace EShop.Entities;

public class Product
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }
    public double Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int Stock {  get; set; }
    public decimal Rate { get; set; }
    public string CoverImage { get; set; } = string.Empty;
    public Guid? CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public Guid SellerId {  get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Category? Category { get; set; }
    public SubCategory? SubCategory { get; set; }
    public User Seller { get; set; } = default!;
    public ICollection<ProductImage> Images { get; set; } = [];
    public ICollection<ProductReview> Reviews { get; set; } = [];
    public ICollection<SoldProduct> Solds { get; set; } = [];
}
