using CryptoTrackerService.Tests.Fixtures;
using Xunit;

namespace CryptoTrackerService.Tests;

public class MapperTests(AutoMapperDiFixture fixture) : IClassFixture<AutoMapperDiFixture>
{
    [Fact]
    public void AutoMapper_ShouldAssertConfigurationIsValid_WhenStartApp()
    {
        _ = new AutoMapperDiFixture();
        Assert.True(true);
    }
}