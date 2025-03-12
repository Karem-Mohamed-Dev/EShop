namespace EShop.Persistence.Configurations.Seeding;

public class Users : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User
        {
            Id = Guid.Parse(DefaultUsers.Admin.Id),
            UserName = "Admin_Name",
            NormalizedUserName = "Admin_Name".ToUpper(),
            Email = DefaultUsers.Admin.Email,
            NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Admin.PasswordHash,
            ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
            SecurityStamp = DefaultUsers.Admin.SecurityStamp,
            CreatedAt = DateTime.Parse("2025-03-09 23:38:54.579194+02")
        });

        builder.HasData(new User
        {
            Id = Guid.Parse(DefaultUsers.Client.Id),
            UserName = "Client_Name",
            NormalizedUserName = "Client_Name".ToUpper(),
            Email = DefaultUsers.Client.Email,
            NormalizedEmail = DefaultUsers.Client.Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Client.PasswordHash,
            ConcurrencyStamp = DefaultUsers.Client.ConcurrencyStamp,
            SecurityStamp = DefaultUsers.Client.SecurityStamp,
            CreatedAt = DateTime.Parse("2025-03-09 23:38:54.579194+02")
        });

        builder.HasData(new User
        {
            Id = Guid.Parse(DefaultUsers.Seller.Id),
            UserName = "Seller_Name",
            NormalizedUserName = "Seller_Name".ToUpper(),
            Email = DefaultUsers.Seller.Email,
            NormalizedEmail = DefaultUsers.Seller.Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Seller.PasswordHash,
            ConcurrencyStamp = DefaultUsers.Seller.ConcurrencyStamp,
            SecurityStamp = DefaultUsers.Seller.SecurityStamp,
            CreatedAt = DateTime.Parse("2025-03-09 23:38:54.579194+02")
        });
    }
}
