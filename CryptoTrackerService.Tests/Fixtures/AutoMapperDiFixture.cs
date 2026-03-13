using Microsoft.Extensions.DependencyInjection;
using CryptoTrackerService.Gateway.Configurations;

namespace CryptoTrackerService.Tests.Fixtures;

public sealed class AutoMapperDiFixture : IDisposable
{
    public IServiceCollection? Services { get; private set; }
    public IServiceProvider? Provider { get; private set; }
    public AutoMapperDiFixture()
    {
        Services = new ServiceCollection().AddLogging();
        
        Services.ConfigureMapper();
        
        Provider = Services.BuildServiceProvider();
        Provider.ValidateMappingProfiles();
    }
    
    public void Dispose()
    {
        Services = null;
        Provider = null;
    }
}