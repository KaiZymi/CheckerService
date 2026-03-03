using Core.Abstractions.Models;

namespace Core.Abstractions.Operations;

public interface IGetExchangePriceQueryOperation
{
    Task<Result<int>> GetPriceAsync(GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct);
}