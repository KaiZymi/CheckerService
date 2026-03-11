using CryptoTrackerService.Core;
using CryptoTrackerService.Gateway.Configurations;
using Exchanges.Abstractions;
using Exchanges.Abstractions.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTrackerService.Tests.Fixtures;

public sealed class OperationFixture : IDisposable
{
    private IServiceCollection Services { get; set;}
    public IServiceProvider Provider { get; private set;}
    
    public OperationFixture()
    {
        Services = new ServiceCollection().AddLogging();
        
        Services.ConfigureMapper();
        
        Services.ConfigureCoreServices();
        
        Services.AddKeyedSingleton<IPriceExchangeClient, TestPriceExchangeClient>("TestExchange");
        
        Provider = Services.BuildServiceProvider();
    }
    
    class TestPriceExchangeClient : IPriceExchangeClient
    {
        public Task<PriceExchangeModel> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel)
        {
            return Task.FromResult(new PriceExchangeModel
            {
                Price = 1
            });
        }
    }
    
    public void Dispose()
    {
    }
}


