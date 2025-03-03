
namespace EShop.Persistence.Configurations;

public class ProductReviewConfigurations : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.HasIndex(x => new { x.UserId, x.ProductId }).IsUnique();
        builder.Property(x => x.Comment).HasMaxLength(500);
        builder.Property(x => x.Rate).HasColumnType("decimal(2,1)");
        builder.HasOne(x => x.User)
            .WithMany(x => x.ProductReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
