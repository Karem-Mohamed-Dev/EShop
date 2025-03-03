namespace EShop.Entities;

public class Cart
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public ICollection<CartProduct> CartProducts { get; set; } = [];
}
