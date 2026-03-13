using AutoMapper;
using Core.Abstractions.Models;
using CryptoTrackerService.Gateway.Models;
using CryptoTrackerService.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CryptoTrackerService.Tests;

public class GatewayMappingTests(AutoMapperDiFixture fixture) : IClassFixture<AutoMapperDiFixture>
{
    private readonly IMapper _mapper = fixture.Provider!.GetRequiredService<IMapper>();

    [Fact]
    public void Map_PriceDtoToGetPriceQueryOperationModel_ShouldWorkCorrectly()
    {
        // Arrange
        var dto = new PriceDto
        {
            PairName = "BTCUSDT",
            ExchangeName = "Binance"
        };

        // Act
        var result = _mapper.Map<GetPriceQueryOperationModel>(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dto.PairName, result.PairName);
        Assert.Equal(dto.ExchangeName, result.ExchangeName);
    }
}
