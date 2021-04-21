using Fra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    public static class FraHostBuilderExtensions
    {
        public static IHostBuilder UseNetCoreDIAutowired(this IHostBuilder builder)
        {
            var serviceProviderFactory = new AutowiredServiceProviderFactory();

            return builder.ConfigureServices((_, services) =>
             {
                 services.AddObjectAccessor(serviceProviderFactory);
             }).UseServiceProviderFactory(serviceProviderFactory);
        }
    }
}
