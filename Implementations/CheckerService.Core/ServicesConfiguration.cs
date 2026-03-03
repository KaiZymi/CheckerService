using CheckerService.Core.Operations;
using Core.Abstractions.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace CheckerService.Core;

public static class ServiceConfiguration
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGetExchangePriceQueryOperation, GetPriceOperations>();
    }
}