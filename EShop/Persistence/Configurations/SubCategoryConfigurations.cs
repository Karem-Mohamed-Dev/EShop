
namespace EShop.Persistence.Configurations;

public class SubCategoryConfigurations : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasKey(x => x.Id);
    }
}
