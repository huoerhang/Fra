using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fra.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Fra
{
    public abstract class ApplicationBase : IApplication
    {
        protected ApplicationBase(Type appEntryModuleType, IServiceCollection services, Action<ApplicationCreationOptions>? optionsAction)
        {
            appEntryModuleType.CheckNotNull(nameof(appEntryModuleType));
            appEntryModuleType.CheckEntryModuleType();
            services.CheckNotNull(nameof(services));

            EntryModuleType = appEntryModuleType;
            Services = services;
            var options = new ApplicationCreationOptions(services);
            optionsAction?.Invoke(options);
            services.AddSingleton<IApplication>(this);
            services.AddSingleton<IModuleContainer>(this);
            services.AddCoreServices();
            services.AddCoreFraServices(this, options);
            Modules = LoadModules(services, options);
            ConfigureServices();
        }

        public Type EntryModuleType { get; }

        public IServiceCollection Services { get; }

        [AllowNull]
        public IServiceProvider ServiceProvider { get; protected set; }

        public IReadOnlyCollection<AppModuleDescriptor> Modules { get; }

        protected virtual IReadOnlyCollection<AppModuleDescriptor> LoadModules(IServiceCollection services, ApplicationCreationOptions options)
        {
            return services.GetSingleInstance<ModuleLoader>().LoadModules(services, EntryModuleType);
        }

        protected virtual void ConfigureServices()
        {
            var context = new ServiceConfigurationContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is AppModule fraModule)
                {
                    fraModule.ServiceConfigurationContext = context;
                }

                Services.AddAssembly(module.ModuleType.Assembly);
            }

            ExecutePreConfigureServices(context);
            ExecuteConfigureServices(context);
            ExecutePostConfigureServices(context);

            foreach (var module in Modules)
            {
                if (module.Instance is AppModule fraModule)
                {
                    fraModule.ServiceConfigurationContext = null;
                }
            }
        }

        private void ExecutePreConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                foreach (var module in Modules)
                {
                    module.Instance.PreConfigureServices(context);
                }
            }
            catch (Exception ex)
            {
                throw new FraException($"An error occurred during {nameof(IAppModule.PreConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        private void ExecuteConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                foreach (var module in Modules)
                {
                    module.Instance.ConfigureServices(context);
                }
            }
            catch (Exception ex)
            {
                throw new FraException($"An error occurred during {nameof(IAppModule.ConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        private void ExecutePostConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                foreach (var module in Modules)
                {
                    module.Instance.PostConfigureServices(context);
                }
            }
            catch (Exception ex)
            {
                throw new FraException($"An error occurred during {nameof(IAppModule.PostConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        public virtual void Initialize()
        {
        }

        public virtual void ShutDown()
        {
            //throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
        }
    }
}
