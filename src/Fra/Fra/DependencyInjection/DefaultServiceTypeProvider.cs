using System;
using System.Reflection;

namespace Fra.DependencyInjection
{
    /// <summary>
    /// TODO:启动应用时注册DefaultServiceTypeProvider
    /// </summary>
    public class DefaultServiceTypeProvider : IServiceTypeProvider
    {
        public Type[] GetServiceTypes(Type targetType)
        {
            return targetType.GetTypeInfo().GetInterfaces();
        }
    }
}
