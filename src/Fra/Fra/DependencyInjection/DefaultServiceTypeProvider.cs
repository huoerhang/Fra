using System;
using System.Linq;
using System.Reflection;

namespace Fra.DependencyInjection
{
    /// <summary>
    /// TODO:启动应用时注册DefaultServiceTypeProvider
    /// </summary>
    internal class DefaultServiceTypeProvider : BaseServiceTypeProvider, IServiceTypeProvider
    {
        public Type[] GetServiceTypes(Type targetType)
        {
            return targetType.GetTypeInfo().GetInterfaces();
        }

        public override ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType)
        {
            var serviceTypes = implementationType.GetTypeInfo().GetInterfaces().Where(c => c.Name == "I" + implementationType.Name);
            var serviceLifetime = base.GetServiceLifetime(implementationType);

            return new ServiceTypeDescriptor(serviceTypes, implementationType, serviceLifetime);
        }
    }
}
