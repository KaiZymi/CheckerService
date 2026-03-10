using AutoMapper;
using Core.Abstractions;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using Exchanges.Abstractions;
using Exchanges.Abstractions.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTrackerService.Core.Operations;

internal sealed class GetPriceOperations(
    IServiceProvider provider,
    IMapper mapper
) : IGetPriceQueryOperation
{
    public async Task<Result<GetPriceQueryResultOperationModel>> GetPriceAsync(
        GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct)
    {
        var client = provider.GetRequiredKeyedService<IPriceExchangeClient>(getPriceOperationModel.ExchangeName);
        
        var getPriceModel = mapper.Map<GetPriceExchangeModel>(getPriceOperationModel);

        var result = await client.GetPriceQueryAsync(getPriceModel);
        
        var responseModel = mapper.Map<GetPriceQueryResultOperationModel>(result);
        
        return responseModel;
    }
}