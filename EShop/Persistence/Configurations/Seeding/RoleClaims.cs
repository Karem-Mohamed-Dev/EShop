namespace EShop.Persistence.Configurations.Seeding;

public class RoleClaims : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{

    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        var permissions = Permissions.GetAllPermissions();
        var adminClaims = new List<IdentityRoleClaim<Guid>>();

        for(int i = 0; i < permissions.Count; i++)
        {
            adminClaims.Add(new IdentityRoleClaim<Guid>
            {
                ClaimType = Permissions.Type,
                ClaimValue = permissions[i],
                RoleId = Guid.Parse(DefaultRoles.Admin.Id),
                Id = i + 1,
            });
        }
        builder.HasData(adminClaims);
    }
}
