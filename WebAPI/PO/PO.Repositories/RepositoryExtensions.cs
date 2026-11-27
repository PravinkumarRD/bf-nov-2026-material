using Microsoft.Extensions.DependencyInjection;
using PO.Application.Contracts;
using PO.Models;

namespace PO.Repositories;

public static class RepositoryExtensions
{
    public static IServiceCollection AddInfrastructureRegistrations(this IServiceCollection services)
    {
        services.AddScoped<ICommonRepository<Customer>, CommonRepository<Customer>>();

        return services;
    }
}
