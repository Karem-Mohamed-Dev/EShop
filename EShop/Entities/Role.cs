namespace EShop.Entities;

public class Role : IdentityRole<Guid>
{
    public Role()
    {
        Id = Guid.CreateVersion7();
    }
    public bool IsDefault { get; set; }
    public bool IsDisabled { get; set; }
}
