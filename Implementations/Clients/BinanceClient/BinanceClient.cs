using Exchanges.Abstractions;
using Exchanges.Abstractions.Options;
using Microsoft.Extensions.Options;

namespace BinanceClient;

internal sealed class BinanceClient(
    IOptions<ExchangeOptions> exchangeOptions
) : IExchangeClient
{
    public async Task<decimal> GetExchangePriceAsync(string pairName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}