using System;
using System.Linq;
using Fra.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionObjectInstanceAccessorExtensions
    {
        public static IServiceCollection AddObjectInstance<T>(this IServiceCollection services, T instance)
            where T : notnull
        {
            if (services.Any(c => c.ServiceType == typeof(ObjectInstanceAccessor<T>)))
            {
                throw new Exception($"The instance of {instance.GetType().AssemblyQualifiedName} is registered.");
            }

            services.Insert(0, new ServiceDescriptor(typeof(ObjectInstanceAccessor<T>), new ObjectInstanceAccessor<T>(instance)));

            return services;
        }

        public static IServiceCollection TryAddObjectInstance<T>(this IServiceCollection services, T instance)
            where T : notnull
        {
            if (!services.Any(c => c.ServiceType == typeof(ObjectInstanceAccessor<T>)))
            {
                return services.AddObjectInstance<T>(instance);
            }

            return services;
        }

        public static T? GetObjectInstanceOrNull<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetFirstInstanceOrNull<ObjectInstanceAccessor<T>>()?.Value;
        }

        public static T GetObjectInstance<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetObjectInstanceOrNull<T>() ?? throw new Exception($"Could not find an object instance of {typeof(T).AssemblyQualifiedName}.");
        }
    }
}
