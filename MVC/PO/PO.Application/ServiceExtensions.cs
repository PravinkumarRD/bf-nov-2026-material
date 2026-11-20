using Microsoft.Extensions.DependencyInjection;
using PO.Application.Services;

namespace PO.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddServiceRegistrations(this IServiceCollection collection)
    {
        collection.AddScoped<CustomerService>();

        return collection;
    }
}
