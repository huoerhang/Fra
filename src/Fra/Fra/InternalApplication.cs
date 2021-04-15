using Fra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fra
{
    internal class InternalApplication : ApplicationBase
    {
        public InternalApplication(Type appEntryModuleType, IServiceCollection services, Action<ApplicationCreationOptions>? optionsAction)
            : base(appEntryModuleType, services, optionsAction)
        {

        }

        public override void Initialize()
        {
            if (ServiceProvider == null)
            {
                throw new FraException($"The ServiceProvider is null.");
            }

            var serviceProvider = ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>();

            if (serviceProvider == null)
            {
                throw new FraException($"The {nameof(IServiceProvider)} is null.");
            }

            ServiceProvider = serviceProvider.Value;
            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
