using System;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.DependencyInjection
{
    public class ServiceTypeDescriptor
    {
        public ServiceTypeDescriptor(Type[] serviceTypes, Type implementationType, ServiceLifetime serviceLifetime)
        {
            serviceTypes.CheckNotNull(nameof(serviceTypes));
            implementationType.CheckNotNull(nameof(implementationType));
            ServiceTypes = serviceTypes;
            ImplementationType = implementationType;
            ServiceLifetime = serviceLifetime;
        }

        public Type[] ServiceTypes { get; private set; }

        public Type ImplementationType { get; private set; }

        public ServiceLifetime ServiceLifetime { get; private set; }
    }
}
