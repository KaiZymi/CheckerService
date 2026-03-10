using AutoMapper;
using BinanceClient;
using BybitClient;
using CryptoTrackerService.Core;
using CryptoTrackerService.Gateway.Profiles;

namespace CryptoTrackerService.Gateway.Configurations;

internal static class AutoMapperConfiguration
{
    public static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(mc =>
        {
            mc.ConfigureGatewayProfiles();
            mc.ConfigureCoreProfiles();
            mc.ConfigureBybitProfiles();
            mc.ConfigureBinanceProfiles();
        });
    }

    public static void ValidateMappingProfiles(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetRequiredService<IMapper>()
            .ConfigurationProvider
            .AssertConfigurationIsValid();
    }
}

