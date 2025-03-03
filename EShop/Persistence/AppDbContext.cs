namespace EShop.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<SoldProduct> SoldProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}