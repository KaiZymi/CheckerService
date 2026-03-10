using AutoMapper;
using Core.Abstractions.Models;
using Exchanges.Abstractions.Models;

namespace CryptoTrackerService.Core.MappingProfiles;

internal class CoreProfile : Profile
{
    public CoreProfile()
    {
        CreateMap<GetPriceQueryOperationModel, GetPriceExchangeModel>();
        CreateMap<PriceExchangeModel, GetPriceQueryResultOperationModel>();
    }
}