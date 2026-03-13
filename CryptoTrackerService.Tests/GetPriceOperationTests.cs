using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using CryptoTrackerService.Tests.Fixtures;
using Exchanges.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CryptoTrackerService.Tests;

public class GetPriceOperationTests
{
    [Fact]
    public async Task GetPriceAsync_ShouldReturnOne_WhenExchangeReturnsOne()
    {

        var fixture = new OperationFixture();
        
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

    [Fact]
    public async Task GetPriceAsync_ShouldReturnPrice_WhenByBitExchangeIsCalled()
    {
        var fixture = new OperationFixture();
        
        // Arrange
        fixture.Services.AddKeyedSingleton<IPriceExchangeClient, TestPriceExchangeClient>("ByBit", (sp, key) => new TestPriceExchangeClient(200.5m));
        var provider = fixture.Services.BuildServiceProvider();
        var operation = provider.GetRequiredService<IGetPriceQueryOperation>();
        
        var model = new GetPriceQueryOperationModel
        {
            PairName = "ETHUSD",
            ExchangeName = "ByBit"
        };

        // Act
        var result = await operation.GetPriceAsync(model, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200.5m, result.Value.Price);
    }

    [Fact]
    public async Task GetPriceAsync_ShouldThrowInvalidOperationException_WhenExchangeDoesNotExist()
    {
        var fixture = new OperationFixture();
        
        // Arrange
        var operation = fixture.Provider.GetRequiredService<IGetPriceQueryOperation>();
        var model = new GetPriceQueryOperationModel
        {
            PairName = "BTCUSD",
            ExchangeName = "NonExistentExchange"
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => operation.GetPriceAsync(model, CancellationToken.None));
    }
}

