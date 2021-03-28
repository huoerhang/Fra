using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.DependencyInjection
{
    internal class ServiceTypeProviderContainer : List<IServiceTypeProvider>
    {
        private static ServiceTypeProviderContainer _container = null;

        private ServiceTypeProviderContainer()
        {
        }

        static ServiceTypeProviderContainer()
        {
            _container = new ServiceTypeProviderContainer();
        }

        internal static ServiceTypeProviderContainer Instance
        {
            get
            {
                return _container;
            }
        }
    }
}
