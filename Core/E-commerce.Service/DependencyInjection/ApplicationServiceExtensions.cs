using E_commerce.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_commerce.Service.DependencyInjection;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}
