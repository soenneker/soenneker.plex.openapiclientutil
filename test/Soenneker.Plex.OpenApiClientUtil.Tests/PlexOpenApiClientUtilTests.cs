using Soenneker.Plex.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Plex.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PlexOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IPlexOpenApiClientUtil _openapiclientutil;

    public PlexOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IPlexOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
