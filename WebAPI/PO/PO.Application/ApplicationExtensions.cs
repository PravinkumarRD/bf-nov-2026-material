using Microsoft.Extensions.DependencyInjection;
using PO.Application.Services;
using PO.Models;

namespace PO.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddServiceRegistrations(this IServiceCollection services)
    {
        services.AddScoped<CustomersService>();
        
        return services;
    }
}
