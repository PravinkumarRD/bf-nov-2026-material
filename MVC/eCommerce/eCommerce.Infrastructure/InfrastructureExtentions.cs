using eCommerce.Application.Contracts;
using eCommerce.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class InfrastructureExtentions
{
    public static IServiceCollection AddInfrastructureRegistrations(this IServiceCollection services)
    {
        services.AddScoped<ICommonRepository<Category>, CommonRepository<Category>>();
        services.AddScoped<ICommonRepository<Product>, CommonRepository<Product>>();
        services.AddScoped<ICommonRepository<Cart>, CommonRepository<Cart>>();
        services.AddScoped<ICommonRepository<CartItem>, CommonRepository<CartItem>>();

        services.AddScoped<ICommonQueriesRepository, CommonQueriesRepository>();

        return services;
    }
}
