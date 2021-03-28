using System;

namespace Fra.DependencyInjection
{
    public interface IServiceTypeProvider
    {
        Type[] GetServiceTypes(Type targetType);
    }
}
