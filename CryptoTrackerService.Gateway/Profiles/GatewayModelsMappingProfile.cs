using AutoMapper;
using Core.Abstractions.Models;
using CryptoTrackerService.Gateway.Models;

namespace CryptoTrackerService.Gateway.Profiles;

internal sealed class GatewayModelsMappingProfile : Profile
{
    public GatewayModelsMappingProfile()
    {
        CreateMap<PriceDto, GetPriceQueryOperationModel>();
    }
}