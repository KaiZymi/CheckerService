using Core.Abstractions.Models;

namespace Core.Abstractions.Operations;

public interface IGetPriceQueryOperation
{
    Task<Result<GetPriceQueryResultOperationModel>> GetPriceAsync(GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct);
}