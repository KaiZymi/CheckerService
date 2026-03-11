using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using CryptoTrackerService.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CryptoTrackerService.Tests;

public class GetPriceOperationTests(OperationFixture fixture) : IClassFixture<OperationFixture>
{
    [Fact]
    public async Task GetPriceAsync_ShouldReturnOne_WhenExchangeReturnsOne()
    {
        // Arrange
        var operation = fixture.Provider.GetRequiredService<IGetPriceQueryOperation>();
        var model = new GetPriceQueryOperationModel
        {
            PairName = "BTCUSD",
            ExchangeName = "TestExchange"
        };
        var ct = CancellationToken.None;

        // Act
        var result = await operation.GetPriceAsync(model, ct);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value.Price);
    }
}
