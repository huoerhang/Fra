using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.DependencyInjection
{
    public abstract class BaseServiceTypeProvider : IServiceTypeProvider
    {
        public abstract ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);

        protected virtual ServiceLifetime GetServiceLifetime(Type implementationType)
        {
            var typeInfo = implementationType.GetTypeInfo();

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
