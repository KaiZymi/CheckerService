using Core.Abstractions.Models;

namespace Core.Abstractions.Operations;

public interface IGetExchangePriceQueryOperation
{
    Task<Result<GetPriceQueryResultOperationModel>> GetPriceAsync(GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct);
}