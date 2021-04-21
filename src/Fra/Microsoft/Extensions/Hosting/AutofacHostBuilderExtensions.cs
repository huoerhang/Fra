using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    public static class AutofacHostBuilderExtensions
    {
        public static IHostBuilder UserAutofac(this IHostBuilder hostBuilder)
        {
            var containerBuilder = new ContainerBuilder();

            return hostBuilder.ConfigureServices((_, services) =>
             {
                 services.AddObjectAccessor(containerBuilder);
             }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}
