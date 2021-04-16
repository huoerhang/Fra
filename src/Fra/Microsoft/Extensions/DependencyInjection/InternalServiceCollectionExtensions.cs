using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra;
using Fra.Modularity;
using Fra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class InternalServiceCollectionExtensions
    {
        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging();
        }

        internal static void AddCoreFraServices(this IServiceCollection services, IApplication fraApplication, ApplicationCreationOptions fraApplicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();
            services.TryAddSingleton(moduleLoader);
            services.AddAssemblyOf<IApplication>();
        }
    }
}
