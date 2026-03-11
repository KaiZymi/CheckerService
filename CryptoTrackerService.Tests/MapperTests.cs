using Xunit;
using CryptoTrackerService.Tests.Fixtures;

namespace CryptoTrackerService.Tests;

public class MapperTests
{
    [Fact]
    public void AutoMapper_ShouldAssertConfigurationIsValid_WhenStartApp()
    {
        _ = new AutoMapperDiFixture();
        Assert.True(true);
    }
}