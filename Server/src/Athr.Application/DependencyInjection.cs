using FluentValidation;
using Athr.Application.Abstractions.Behaviors;
using Athr.Domain.BuildingBlocks;
using Microsoft.Extensions.DependencyInjection;

namespace Athr.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddFluentValidator(services);

        AddMediatR(services);

        AddStrategies(services);

        return services;
    }

    private static void AddFluentValidator(IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);
    }

    private static void AddMediatR(IServiceCollection services)
    {
        services.AddMediatR(
        configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(QueryCachingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
    }

    private static void AddStrategies(IServiceCollection services)
    {
        var openGenericStatusInterface = typeof(IStatusTransitionStrategy<,>);
        var strategyTypes =
            AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t is { IsClass: true, IsAbstract: false })
                .Select(t => new
                {
                    Implementation = t,
                    Interface = t.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType &&
                                             (i.GetGenericTypeDefinition() == openGenericStatusInterface ) )
                })
                .Where(x => x.Interface != null)
                .ToList();

        foreach (var strategy in strategyTypes)
        {
            // Register each strategy dynamically
            services.AddScoped(strategy.Interface!, strategy.Implementation);
        }
    }

}
