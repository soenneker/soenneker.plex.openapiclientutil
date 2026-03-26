using Soenneker.Plex.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Plex.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IPlexOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<PlexOpenApiClient> Get(CancellationToken cancellationToken = default);
}
