namespace EShop;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConnectToDatabase(configuration);
        services.AddAuthConfig();
        return services;
    }

    public static IServiceCollection ConnectToDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Default") ??
            throw new InvalidOperationException("Connection String 'Default' was not found");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }

    public static IServiceCollection AddAuthConfig(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


        return services;
    }
}
