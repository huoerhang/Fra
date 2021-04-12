using Fra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra
{
    internal class InternalApplication : ApplicationBase
    {
        public InternalApplication(Type appEntryModuleType, IServiceCollection services, Action<ApplicationCreationOptions> optionsAction)
            : base(appEntryModuleType, services, optionsAction)
        {

        }

        public override void Initialize()
        {
            var serviceProvider = ServiceProvider.GetRequiredService<ObjectInstanceAccessor<IServiceProvider>>();

            if (serviceProvider == null)
            {
                throw new FraException($"The {nameof(IServiceProvider)} is null.");
            }

            ServiceProvider = serviceProvider.Value;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
