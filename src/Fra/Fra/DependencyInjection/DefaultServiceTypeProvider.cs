using System;
using System.Reflection;

namespace Fra.DependencyInjection
{
    /// <summary>
    /// TODO:启动应用时注册DefaultServiceTypeProvider
    /// </summary>
    public class DefaultServiceTypeProvider : BaseServiceTypeProvider, IServiceTypeProvider
    {
        public Type[] GetServiceTypes(Type targetType)
        {
            return targetType.GetTypeInfo().GetInterfaces();
        }

        public override ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType)
        {
            var services = implementationType.GetTypeInfo().GetInterfaces();
            var serviceLifetime = base.GetServiceLifetime(implementationType);

            return new ServiceTypeDescriptor(services, implementationType, serviceLifetime);
        }
    }
}
