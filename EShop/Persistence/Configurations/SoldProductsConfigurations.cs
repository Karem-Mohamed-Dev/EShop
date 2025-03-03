
namespace EShop.Persistence.Configurations;

public class SoldProductsConfigurations : IEntityTypeConfiguration<SoldProduct>
{
    public void Configure(EntityTypeBuilder<SoldProduct> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(7,2)");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Solds)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Seller)
            .WithMany()
            .HasForeignKey(x => x.SellerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
