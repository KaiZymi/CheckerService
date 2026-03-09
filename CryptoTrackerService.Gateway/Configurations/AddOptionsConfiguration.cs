using Exchanges.Abstractions.Options;

namespace CryptoTrackerService.Gateway.Configurations;

internal static class AddOptionsConfiguration
{
    public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ExchangeOptions>().Bind(configuration.GetSection(nameof(ExchangeOptions)));
    }
}