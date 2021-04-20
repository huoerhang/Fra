using System;

namespace Fra.DependencyInjection
{
    public abstract class BaseServiceTypeProvider : IServiceTypeProvider
    {
        public abstract ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}
