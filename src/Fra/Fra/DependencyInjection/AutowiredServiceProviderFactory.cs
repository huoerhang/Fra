using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fra.DependencyInjection
{
    public class AutowiredServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
    {
        public IServiceCollection CreateBuilder(IServiceCollection services)
        {
            if (services == null)
            {
                return new ServiceCollection();
            }

            return services;
        }

        public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
        {
            var serviceProvider = containerBuilder.BuildServiceProvider();

            return new AutowiredServiceProvider(serviceProvider);
        }
    }
}
