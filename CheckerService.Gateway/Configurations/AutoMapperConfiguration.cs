using AutoMapper;
using BinanceClient;
using BybitClient;
using CheckerService.Core;
using CheckerService.Gateway.Profiles;

namespace CheckerService.Gateway.Configurations;

public static class AutoMapperConfiguration
{
    public static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.ConfigureGatewayProfiles();
            mc.ConfigureCoreProfiles();
            mc.ConfigureBybitProfiles();
            mc.ConfigureBinanceProfiles();
        });
        mapperConfig.AssertConfigurationIsValid();
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }

    private static void ConfigureGatewayProfiles(this IMapperConfigurationExpression mc)
    {
        var profiles = typeof(GatewayModelsMappingProfile)
            .Assembly
            .GetTypes()
            .Where(x => typeof(Profile).IsAssignableFrom(x));

        foreach (var profile in profiles)
        {
            mc.AddProfile(Activator.CreateInstance(profile) as Profile);
        }
    }
}
