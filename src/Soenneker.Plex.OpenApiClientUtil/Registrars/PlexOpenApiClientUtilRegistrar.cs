using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Plex.HttpClients.Registrars;
using Soenneker.Plex.OpenApiClientUtil.Abstract;

namespace Soenneker.Plex.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class PlexOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Plex OpenAPI client utility as a singleton service.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPlexOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPlexOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPlexOpenApiClientUtil, PlexOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Plex OpenAPI client utility as a scoped service backed by the singleton Plex HTTP client.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPlexOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPlexOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPlexOpenApiClientUtil, PlexOpenApiClientUtil>();

        return services;
    }
}
