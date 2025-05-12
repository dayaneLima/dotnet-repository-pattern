using Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryPattern.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(typeof(DependencyInjection).Assembly);
        return services;
    }
}