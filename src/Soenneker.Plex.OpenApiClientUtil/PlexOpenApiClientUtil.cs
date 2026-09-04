using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Plex.HttpClients.Abstract;
using Soenneker.Plex.OpenApiClientUtil.Abstract;
using Soenneker.Plex.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Plex.OpenApiClientUtil;

/// <inheritdoc cref="IPlexOpenApiClientUtil" />
public sealed class PlexOpenApiClientUtil : IPlexOpenApiClientUtil
{
    private readonly AsyncSingleton<PlexOpenApiClient> _client;

    public PlexOpenApiClientUtil(IPlexOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<PlexOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new PlexOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<PlexOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
