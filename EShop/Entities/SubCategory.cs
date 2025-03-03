namespace EShop.Entities;

public class SubCategory
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public ICollection<Product> Products { get; set; } = [];
}
