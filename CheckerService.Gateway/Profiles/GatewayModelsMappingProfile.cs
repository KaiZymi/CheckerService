using AutoMapper;
using CheckerService.Gateway.Models;
using Core.Abstractions.Models;

namespace CheckerService.Gateway.Profiles;

public class GatewayModelsMappingProfile : Profile
{
    public GatewayModelsMappingProfile()
    {
        CreateMap<PriceDto, GetPriceQueryOperationModel>();
    }
}