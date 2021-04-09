using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DependencyAttribute : Attribute
    {
        private readonly ServiceLifetime _lifetime;

        public DependencyAttribute()
        {
            _lifetime = ServiceLifetime.Transient;
        }

        public DependencyAttribute(ServiceLifetime lifetime)
        {
            _lifetime = lifetime;
        }

        public ServiceLifetime Lifetime
            => _lifetime;
    }
}
