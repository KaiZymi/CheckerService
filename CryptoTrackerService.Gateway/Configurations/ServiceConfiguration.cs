using System.Runtime.CompilerServices;
using AutoMapper;

using CryptoTrackerService.Gateway.Profiles;

[assembly: InternalsVisibleTo("CryptoTrackerService.Tests")]

namespace CryptoTrackerService.Gateway.Configurations;

public static class ServiceConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
    }

    public static void ConfigureGatewayProfiles(this IMapperConfigurationExpression mc)
    {
        mc.AddMaps(typeof(GatewayModelsMappingProfile).Assembly);
    }
}