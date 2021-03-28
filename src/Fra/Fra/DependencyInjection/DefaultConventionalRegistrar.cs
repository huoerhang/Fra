using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.DependencyInjection
{
    public class DefaultConventionalRegistrar : ConventionalRegistrarBase
    {
        public override void AddType(IServiceCollection services, Type type)
        {
            var lifetime = GetServiceLifetime(type);
            List<Type> serviceTypes = ServiceTypeExplorer.GetServiceTypes(type);

            foreach(var serviceType in serviceTypes)
            {
                var serviceDescriptor = ServiceDescriptor.Describe(serviceType, type, lifetime);

                services.Add(serviceDescriptor);
            }
        }

        protected virtual ServiceLifetime GetServiceLifetime(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsAssignableTo(typeof(ISingletonDependency)))
            {
                return ServiceLifetime.Singleton;
            }

            if (typeInfo.IsAssignableTo(typeof(IScopeDependency)))
            {
                return ServiceLifetime.Scoped;
            }

            return ServiceLifetime.Transient;
        }
    }
}
