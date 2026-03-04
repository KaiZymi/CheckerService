using Core.Abstractions;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;

namespace CheckerService.Core.Operations;

public sealed class GetPriceOperations : IGetExchangePriceQueryOperation
{
    public Task<Result<int>> GetPriceAsync(GetPriceQueryOperationModel getPriceOperationModel, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}