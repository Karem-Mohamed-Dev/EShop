namespace EShop.Entities;

public class User : IdentityUser<Guid>
{
    public User()
    {
        Id = Guid.CreateVersion7();
    }
    public bool IsDisabled { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Cart Cart { get; set; } = default!;
    public ICollection<Favorite> Favorites { get; set; } = [];
    public ICollection<ProductReview> ProductReviews { get; set; } = [];
}
