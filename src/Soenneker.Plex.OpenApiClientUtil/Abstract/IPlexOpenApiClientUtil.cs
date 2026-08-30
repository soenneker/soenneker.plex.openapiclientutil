using Soenneker.Plex.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Plex.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily initialized Plex OpenAPI client backed by the process-wide Plex HTTP transport.
/// </summary>
public interface IPlexOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured Plex OpenAPI client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached client for this utility instance.</returns>
    ValueTask<PlexOpenApiClient> Get(CancellationToken cancellationToken = default);
}
