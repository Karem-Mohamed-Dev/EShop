namespace EShop.Entities;

public class ProductImage
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public Product Product { get; set; } = default!;
}
