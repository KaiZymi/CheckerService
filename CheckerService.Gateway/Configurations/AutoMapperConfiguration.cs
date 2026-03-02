using AutoMapper;
using CheckerService.Gateway.MappingProfiles;

namespace CheckerService.Gateway.Configurations;

public static class AutoMapperConfiguration
{
    public static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.ConfigureGatewayProfiles();
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
