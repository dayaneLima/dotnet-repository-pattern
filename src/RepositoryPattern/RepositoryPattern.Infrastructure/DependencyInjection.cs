using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Domain.Abstractions;
using RepositoryPattern.Domain.Repositories;
using RepositoryPattern.Infrastructure.Data.Context;
using RepositoryPattern.Infrastructure.Repositories;

namespace RepositoryPattern.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IProductRepository, ProductRepository>();

        return services;
    }
}