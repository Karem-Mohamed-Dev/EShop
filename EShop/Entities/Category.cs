namespace EShop.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<SubCategory> SubCategorys { get; set; } = [];
}
