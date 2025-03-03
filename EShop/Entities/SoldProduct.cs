namespace EShop.Entities;

public class SoldProduct
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public Guid SellerId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Product Product { get; set; } = default!;
    public User User { get; set; } = default!;
    public User Seller { get; set; } = default!;
}