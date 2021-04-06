using System;

namespace Fra.DependencyInjection
{
    public interface IServiceTypeProvider
    {
        ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);

        //Type[] GetServiceTypes(Type targetType);
    }
}
