using AutoMapper;
using Core.Abstractions.Models;
using Exchanges.Abstractions.Models;

namespace CryptoTrackerService.Core.MappingProfiles;

internal class CoreProfile : Profile
{
    public CoreProfile()
    {
        CreateMap<GetPriceQueryOperationModel, GetPriceExchangeModel>()
            .ForMember(dest => dest.Symbol, 
                opt => opt.MapFrom(src => src.PairName));

        CreateMap<PriceExchangeModel, GetPriceQueryResultOperationModel>()
            .ForMember(dest => dest.Price, 
                opt => opt.MapFrom(src => src.Price));
    }
}