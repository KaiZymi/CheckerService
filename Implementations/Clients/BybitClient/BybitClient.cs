using Exchanges.Abstractions;
using Exchanges.Abstractions.Options;
using Microsoft.Extensions.Options;

namespace BybitClient;

internal sealed class BybitClient(
    IOptions<ExchangeOptions> exchangeOptions
) : IExchangeClient
{
    public async Task<decimal> GetExchangePriceAsync(string pairName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}