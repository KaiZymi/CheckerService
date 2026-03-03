using Exchanges.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BinanceClient;

public static class ServiceConfiguration
{
    public static void ConfigureBinanceServices(this IServiceCollection services, string key)
    {
        services.AddKeyedScoped<IExchangeClient, BinanceClient>(key);
    }
}