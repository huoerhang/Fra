using System;
using System.Linq;
using System.Reflection;

namespace Fra.DependencyInjection
{
    internal class DefaultServiceTypeProvider : BaseServiceTypeProvider, IServiceTypeProvider
    {
        public override ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType)
        {
            var typeInfo = implementationType.GetTypeInfo();
            var attribute = typeInfo.GetCustomAttribute<DependencyAttribute>(true);

            if (attribute == null)
            {
                return null;
            }

            var serviceTypes = typeInfo.GetInterfaces().Where(c => c.Name == "I" + implementationType.Name);
            var lifetime = attribute.Lifetime;

            return new ServiceTypeDescriptor(serviceTypes, implementationType, lifetime);
            //var serviceLifetime = base.GetServiceLifetime(implementationType);

            //return new ServiceTypeDescriptor(serviceTypes, implementationType, serviceLifetime);
        }
    }
}
