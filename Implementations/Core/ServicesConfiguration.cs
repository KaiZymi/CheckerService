using AutoMapper;
using Core.Abstractions.Operations;
using CryptoTrackerService.Core.MappingProfiles;
using CryptoTrackerService.Core.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTrackerService.Core;

public static class ServiceConfiguration
{
    public static void ConfigureCoreProfiles(this IMapperConfigurationExpression mc)
    {
        var profiles = typeof(CoreProfile)
            .Assembly
            .GetTypes()
            .Where(x => typeof(Profile).IsAssignableFrom(x));

        foreach (var profile in profiles)
        {
            mc.AddProfile(Activator.CreateInstance(profile) as Profile);
        }
    }
    
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGetPriceQueryOperation, GetPriceOperations>();
    }
}