using AutoMapper;
using BybitClient.MappingProfiles;
using Exchanges.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BybitClient;

public static class ServiceConfiguration
{
    public static void ConfigureBybitProfiles(this IMapperConfigurationExpression mc)
    {
        var profiles = typeof(BybitProfile)
            .Assembly
            .GetTypes()
            .Where(x => typeof(Profile).IsAssignableFrom(x));

        foreach (var profile in profiles)
        {
            mc.AddProfile(Activator.CreateInstance(profile) as Profile);
        }
    }
    
    public static void ConfigureCoreBybitServices(this IServiceCollection services, string key)
    {
        services.AddKeyedScoped<IExchangeClient, BybitClient>(key);
    }
}