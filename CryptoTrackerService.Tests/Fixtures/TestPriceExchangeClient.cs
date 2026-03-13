using Exchanges.Abstractions;
using Exchanges.Abstractions.Models;

namespace CryptoTrackerService.Tests.Fixtures;

public class TestPriceExchangeClient(decimal price = 1) : IPriceExchangeClient
{
    public Task<PriceExchangeModel> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel)
    {
        return Task.FromResult(new PriceExchangeModel
        {
            Price = price
        });
    }
}
