using AutoMapper;
using CryptoTrackerService.Gateway.Extensions;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using CryptoTrackerService.Gateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTrackerService.Gateway.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PriceController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<decimal>> GetPriceFromExchange(
        [FromQuery] PriceDto priceDto,
        [FromServices] IMapper mapper,
        [FromServices] IGetExchangePriceQueryOperation queryOperations,
        CancellationToken ct)
    {
        var operationModel = mapper.Map<GetPriceQueryOperationModel>(priceDto);
        var result = await queryOperations.GetPriceAsync(operationModel, ct);
        if (result.IsFailure)
            return result.Error.ToResponse();
        return result.Value.Price;
    }
}