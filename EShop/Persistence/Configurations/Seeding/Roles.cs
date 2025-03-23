namespace EShop.Persistence.Configurations.Seeding;

public class Roles : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role
        {
            Id = Guid.Parse(DefaultRoles.Admin.Id),
            Name = DefaultRoles.Admin.Name,
            ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp,
            NormalizedName = DefaultRoles.Admin.Name.ToUpper()
        });

        builder.HasData(new Role
        {
            Id = Guid.Parse(DefaultRoles.Client.Id),
            Name = DefaultRoles.Client.Name,
            ConcurrencyStamp = DefaultRoles.Client.ConcurrencyStamp,
            NormalizedName = DefaultRoles.Client.Name.ToUpper(),
            IsDefault = true
        });
    }
}
