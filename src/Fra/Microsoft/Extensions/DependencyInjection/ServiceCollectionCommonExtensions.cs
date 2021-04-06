using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionCommonExtensions
    {
        public static bool IsAdded(this IServiceCollection services, Type serviceType)
        {
            return services.Any(t => t.ServiceType == serviceType);
        }

        public static bool IsAdded<T>(this IServiceCollection services)
        {
            return services.IsAdded(typeof(T));
        }

        public static T GetFirstInstanceOrNull<T>(this IServiceCollection services)
        {
            return (T)services.FirstOrDefault(c => c.ServiceType == typeof(T))?.ImplementationInstance;
        }

        public static T GetSingletonInstance<T>(this IServiceCollection services)
        {
            var service = services.GetFirstInstanceOrNull<T>();

            if (service == null)
            {
                throw new InvalidOperationException($"Not found service:{typeof(T).AssemblyQualifiedName}");
            }

            return service;
        }
    }
}
