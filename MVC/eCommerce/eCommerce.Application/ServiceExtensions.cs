using eCommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddServiceRegistrations(this IServiceCollection services)
    {
        services.AddScoped<CategoriesService>();
        services.AddScoped<ProductsService>();
        services.AddScoped<CartsService>();
        services.AddScoped<CartItemsService>();
        services.AddScoped<CommonQueriesService>();
        return services;
    }
}
