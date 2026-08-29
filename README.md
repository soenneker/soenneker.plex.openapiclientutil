[![](https://img.shields.io/nuget/v/soenneker.plex.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.plex.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.plex.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.plex.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.plex.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.plex.openapiclientutil/)

# Soenneker.Plex.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Plex.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Plex.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddPlexOpenApiClientUtilAsSingleton();
```

Adds `PlexOpenApiClientUtil` as a singleton service.

## What you get

- `IPlexOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `PlexOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `PlexOpenApiClientUtilRegistrar.AddPlexOpenApiClientUtilAsSingleton(services)` | Adds `PlexOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `PlexOpenApiClientUtilRegistrar.AddPlexOpenApiClientUtilAsScoped(services)` | Adds `PlexOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
