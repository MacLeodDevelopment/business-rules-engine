using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Infrastructure;
using BusinessRulesEngine.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessRulesEngine.IoC
{
    public class DependencyResolver
    {
        public static ServiceProvider ServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IOrderProcessor, OrderProcessor>();
            serviceCollection.AddSingleton<IRuleMatchService, RuleMatchService>();
            serviceCollection.AddSingleton<IRuleEngine, RuleEngine>();

            serviceCollection.AddSingleton<IServiceBus, ServiceBusEmulator>();
            serviceCollection.AddSingleton<IRuleRepository, RuleRepositoryEmulator>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}