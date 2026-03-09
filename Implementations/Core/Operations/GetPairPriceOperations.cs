using Core.Abstractions;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using Exchanges.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTrackerService.Core.Operations;

public sealed class GetPriceOperations(IServiceProvider provider) : IGetExchangePriceQueryOperation
{
    public async Task<Result<GetPriceQueryResultOperationModel>> GetPriceAsync(
        GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct)
    {
        var client = provider.GetRequiredKeyedService<IExchangeClient>(getPriceOperationModel.ExchangeName);
        var result = await client.GetExchangePriceAsync(getPriceOperationModel.ExchangeName, ct);
        return new GetPriceQueryResultOperationModel()
        {
            Price = result
        };
    }
}