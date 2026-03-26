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
    /// Adds <see cref="PlexOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPlexOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPlexOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPlexOpenApiClientUtil, PlexOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PlexOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPlexOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPlexOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPlexOpenApiClientUtil, PlexOpenApiClientUtil>();

        return services;
    }
}
