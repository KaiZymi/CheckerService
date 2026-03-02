using AutoMapper;
using CheckerService.Gateway.Models;
using Core.Abstractions.Models;

namespace CheckerService.Gateway.MappingProfiles;

public class GatewayModelsMappingProfile : Profile
{
    public GatewayModelsMappingProfile()
    {
        CreateMap<PriceDto, GetPriceQueryOperationModel>();
    }
}