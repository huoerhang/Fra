using System;
using System.Linq;
using Fra.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionObjectAccessorExtensions
    {
        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, ObjectAccessor<T> objectAccessor)
            where T : notnull
        {
            if (services.Any(c => c.ServiceType == typeof(ObjectAccessor<T>)))
            {
                throw new Exception($"The instance of {typeof(T).AssemblyQualifiedName} is registered.");
            }

            services.Insert(0, new ServiceDescriptor(typeof(ObjectAccessor<T>), objectAccessor));

            return objectAccessor;
        }

        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, T instance)
            where T : notnull
        {
            if (services.Any(c => c.ServiceType == typeof(ObjectAccessor<T>)))
            {
                throw new Exception($"The instance of {instance.GetType().AssemblyQualifiedName} is registered.");
            }

            var accessor = new ObjectAccessor<T>(instance);
            services.Insert(0, new ServiceDescriptor(typeof(ObjectAccessor<T>), accessor));

            return accessor;
        }

        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services)
            where T : notnull
        {
            return services.AddObjectAccessor<T>(new ObjectAccessor<T>());
        }

        public static ObjectAccessor<T> TryAddObjectAccessor<T>(this IServiceCollection services)
            where T : notnull
        {
            if (services.Any(c => c.ServiceType == typeof(ObjectAccessor<T>)))
            {
                return services.GetSingleInstance<ObjectAccessor<T>>();
            }

            return services.AddObjectAccessor<T>();
        }

        public static T? GetObjectAccessorOrNull<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetFirstInstanceOrNull<ObjectAccessor<T>>()?.Value;
        }

        public static T GetObjectAccessor<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetObjectAccessorOrNull<T>() ?? throw new Exception($"Could not find an object instance of {typeof(T).AssemblyQualifiedName}.");
        }
    }
}
