using Soenneker.Plex.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Plex.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class PlexOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IPlexOpenApiClientUtil _openapiclientutil;

    public PlexOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IPlexOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
