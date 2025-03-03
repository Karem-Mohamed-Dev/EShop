namespace EShop.Entities;

public class Favorite
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }

    public Product Product { get; set; } = default!;
    public User User { get; set; } = default!;
}
