using AutoMapper;
using Core.Abstractions.Models;
using CryptoTrackerService.Gateway.Models;

namespace CryptoTrackerService.Gateway.Profiles;

public class GatewayModelsMappingProfile : Profile
{
    public GatewayModelsMappingProfile()
    {
        CreateMap<PriceDto, GetPriceQueryOperationModel>();
    }
}