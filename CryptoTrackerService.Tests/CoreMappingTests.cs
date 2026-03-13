using AutoMapper;
using Core.Abstractions.Models;
using Exchanges.Abstractions.Models;
using CryptoTrackerService.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CryptoTrackerService.Tests;

public class CoreMappingTests(AutoMapperDiFixture fixture) : IClassFixture<AutoMapperDiFixture>
{
    private readonly IMapper _mapper = fixture.Provider!.GetRequiredService<IMapper>();

    [Fact]
    public void Map_PriceExchangeModelToGetPriceQueryResultOperationModel_ShouldWorkCorrectly()
    {
        // Arrange
        var model = new PriceExchangeModel
        {
            Price = 50000.5m
        };

        // Act
        var result = _mapper.Map<GetPriceQueryResultOperationModel>(model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(model.Price, result.Price);
    }
}
