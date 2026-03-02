using Core.Abstractions.Models;

namespace Core.Abstractions.Operations;

public interface IGetExchangePriceQueryOperation
{
    Task<Result<int>> GetPrice(GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct);
}