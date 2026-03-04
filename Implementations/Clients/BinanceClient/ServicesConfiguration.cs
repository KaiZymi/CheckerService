using AutoMapper;
using BinanceClient.MappingProfiles;
using Exchanges.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BinanceClient;

public static class ServiceConfiguration
{
    public static void ConfigureBinanceProfiles(this IMapperConfigurationExpression mc)
    {
        var profiles = typeof(BinanceProfile)
            .Assembly
            .GetTypes()
            .Where(x => typeof(Profile).IsAssignableFrom(x));

        foreach (var profile in profiles)
        {
            mc.AddProfile(Activator.CreateInstance(profile) as Profile);
        }
    }
    
    public static void ConfigureBinanceServices(this IServiceCollection services, string key)
    {
        services.AddKeyedScoped<IExchangeClient, BinanceClient>(key);
    }
}