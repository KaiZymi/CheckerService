using AutoMapper;
using CheckerService.Gateway.Extensions;
using CheckerService.Gateway.Models;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using Microsoft.AspNetCore.Mvc;

namespace CheckerService.Gateway.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PriceController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<int>> GetPrice(
        [FromQuery] PriceDto priceDto,
        [FromServices] IMapper mapper,
        [FromServices] IGetExchangePriceQueryOperation queryOperations,
        CancellationToken ct)
    {
        var operationModel = mapper.Map<GetPriceQueryOperationModel>(priceDto);
        var result = await queryOperations.GetPrice(operationModel, ct);
        if (result.IsFailure)
            return result.Error.ToResponse();
        return result.Value;
    }
}