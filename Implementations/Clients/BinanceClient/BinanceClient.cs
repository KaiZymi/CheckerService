using Exchanges.Abstractions;
using Exchanges.Abstractions.Models;
using Exchanges.Abstractions.Options;
using Microsoft.Extensions.Options;

namespace BinanceClient;

internal sealed class BinanceClient(
    IOptions<ExchangeOptions> exchangeOptions
) : IPriceExchangeClient
{
    public Task<PriceExchangeModel> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel)
    {
        throw new NotImplementedException();
    }
}