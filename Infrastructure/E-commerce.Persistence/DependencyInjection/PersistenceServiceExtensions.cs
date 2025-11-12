using E_commerce.Domain.Entities.Auth;
using E_commerce.Persistence.Context.AuthContext;
using E_commerce.Persistence.Repositories;
using E_commerce.Persistence.Services;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Persistence.DependencyInjection;

public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
         IConfiguration configuration)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddSingleton<IConnectionMultiplexer>(config =>
        {
            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
        });
        services.AddDbContext<StoreDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SQLConnection");
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<ICashService, CashService>();
        services.AddDbContext<AuthDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("AuthConnection");
            options.UseSqlServer(connectionString);
        });
        ConfigureIdentity(services, configuration);
        return services;
    }


    private static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<ApplicationUser>(config =>
        {
            config.Password.RequiredLength = 8;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireUppercase = false;
            config.Password.RequireLowercase = false;
            config.Password.RequireDigit = false;
            config.User.RequireUniqueEmail = true;

        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AuthDbContext>();
    }
}
