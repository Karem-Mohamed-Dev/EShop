namespace EShop.Persistence.Configurations.Seeding;

public class UserRoles : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse(DefaultUsers.Admin.Id),
            RoleId = Guid.Parse(DefaultRoles.Admin.Id),
        });

        builder.HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse(DefaultUsers.Client.Id),
            RoleId = Guid.Parse(DefaultRoles.Client.Id),
        });

        builder.HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse(DefaultUsers.Seller.Id),
            RoleId = Guid.Parse(DefaultRoles.Seller.Id),
        });
    }
}
