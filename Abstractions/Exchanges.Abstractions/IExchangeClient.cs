namespace Exchanges.Abstractions;

public interface IExchangeClient
{
    Task<decimal> GetExchangePriceAsync(string pairName, CancellationToken ct);
}