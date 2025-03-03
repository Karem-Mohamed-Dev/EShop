namespace EShop.Entities;

public class CartProduct
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ProductId { get; set; }
    public Guid CartId { get; set; }
    public int Quantity { get; set; }

    public Product Product { get; set; } = default!;
    public Cart Cart { get; set; } = default!;
}
