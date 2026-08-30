[![](https://img.shields.io/nuget/v/soenneker.plex.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.plex.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.plex.openapiclientutil/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.plex.openapiclientutil/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.plex.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.plex.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.plex.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.plex.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.plex.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.plex.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Plex.OpenApiClientUtil

Creates and caches a configured `PlexOpenApiClient` while reusing the process-wide Plex HTTP transport.

## Installation

```bash
dotnet add package Soenneker.Plex.OpenApiClientUtil
```

## Configuration

```json
{
  "Plex": {
    "ClientBaseUrl": "http://localhost:32400",
    "ApiKey": "your-plex-token"
  }
}
```

Optional `Plex:AuthHeaderName` and `Plex:AuthHeaderValueTemplate` settings support intermediaries that do not use Plex's standard `X-Plex-Token: {token}` format.

## Registration and usage

Register the utility as scoped when callers need a disposable client wrapper while retaining the shared HTTP client and connection pool:

```csharp
using Soenneker.Plex.OpenApiClient;
using Soenneker.Plex.OpenApiClient.Identity;
using Soenneker.Plex.OpenApiClientUtil.Abstract;
using Soenneker.Plex.OpenApiClientUtil.Registrars;

services.AddPlexOpenApiClientUtilAsScoped();

IPlexOpenApiClientUtil plex =
    serviceProvider.GetRequiredService<IPlexOpenApiClientUtil>();

PlexOpenApiClient client = await plex.Get(cancellationToken);
IdentityGetResponse? identity =
    await client.Identity.GetAsync(cancellationToken: cancellationToken);

Console.WriteLine(identity?.MediaContainer?.MachineIdentifier);
```

`Get` is concurrency-safe and returns the same OpenAPI client for the lifetime of the utility. Disposing a scoped utility releases its wrapper but deliberately leaves the singleton HTTP client available to other scopes.

The Plex token is attached only to requests matching the configured server's scheme, host, and port. Automatic redirects are disabled; validate a redirect destination before following it explicitly.
