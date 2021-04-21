using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Fra.DependencyInjection
{
    public class AutowiredServiceProvider : IServiceProvider, ISupportRequiredService
    {
        private readonly IServiceProvider _serviceProvider;
        private static BindingFlags _propertyBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField;

        public AutowiredServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            var instance = _serviceProvider.GetService(serviceType);
            Autowried(instance);

            return instance;
        }

        public object GetRequiredService(Type serviceType)
        {
            var instance = _serviceProvider.GetRequiredService(serviceType);
            Autowried(instance);

            return instance;
            //if(serviceType)
        }

        private void Autowried(object instance)
        {
            if (instance == null || _serviceProvider == null || instance is Type)
            {
                return;
            }

            var type = instance.GetType();
            var properties = type.GetProperties(_propertyBindingFlags).Where(p => p.CanWrite && p.CustomAttributes.Any(a => a.AttributeType == typeof(AutowiredAttribute)));

            foreach (var property in properties)
            {
                var propertyInstance = _serviceProvider.GetRequiredService(property.GetType());

                if (propertyInstance != null)
                {
                    property.SetValue(instance, propertyInstance);
                }
            }
        }
    }
}
