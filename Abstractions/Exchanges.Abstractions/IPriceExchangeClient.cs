using Exchanges.Abstractions.Models;

namespace Exchanges.Abstractions;

public interface IPriceExchangeClient
{
    Task<PriceExchangeModel> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel);
}