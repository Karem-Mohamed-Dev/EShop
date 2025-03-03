
namespace EShop.Persistence.Configurations;

public class CartProductConfigurations : IEntityTypeConfiguration<CartProduct>
{
    public void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        builder.HasIndex(x => new { x.ProductId, x.CartId }).IsUnique();
    }
}
