using Microsoft.Extensions.DependencyInjection;
using PO.Application.Contracts;
using PO.Entites;

namespace PO.Repository;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryRegistrations(this IServiceCollection collection)
    {
        collection.AddScoped<ICommonRepository<Customer>, CommonRepository<Customer>>();
        collection.AddScoped<ICommonRepository<Order>, CommonRepository<Order>>();
        collection.AddScoped<ICommonRepository<Invoice>, CommonRepository<Invoice>>();

        return collection;
    }
}
