﻿using System;
using System.Collections.Generic;
using Fra.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Fra
{
    public abstract class FraApplicationBase : IFraApplication
    {

        protected FraApplicationBase(Type appEntryModuleType, IServiceCollection services, Action<FraApplicationCreationOptions> optionsAction)
        {
            appEntryModuleType.CheckNotNull(nameof(appEntryModuleType));
            appEntryModuleType.CheckEntryModuleType();
            services.CheckNotNull(nameof(services));

            EntryModuleType = appEntryModuleType;
            Services = services;
            var options = new FraApplicationCreationOptions(services);
            optionsAction?.Invoke(options);
            services.AddSingleton<IFraApplication>(this);
            services.AddSingleton<IModuleContainer>(this);
            services.AddCoreServices();
            services.AddCoreFraServices(this, options);
            Modules = LoadModules(services, options);
            ConfigureServices();
        }

        public Type EntryModuleType { get; }

        public IServiceCollection Services { get; }

        public IServiceProvider ServiceProvider { get; }

        public IReadOnlyCollection<FraModuleDescriptor> Modules { get; }

        protected virtual IReadOnlyCollection<FraModuleDescriptor> LoadModules(IServiceCollection services, FraApplicationCreationOptions options)
        {
            return services.GetSingleInstance<ModuleLoader>().LoadModules(services, EntryModuleType);
        }

        protected virtual void ConfigureServices()
        {
            var context = new ServiceConfigurationContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is FraModule fraModule)
                {
                    fraModule.ServiceConfigurationContext = context;
                }
            }

            InvokePreConfigureServices(context);
            InvokeConfigureServices(context);
            InvokePostConfigureServices(context);

            foreach (var module in Modules)
            {
                if (module.Instance is FraModule fraModule)
                {
                    fraModule.ServiceConfigurationContext = null;
                }
            }
        }

        private void InvokePreConfigureServices(ServiceConfigurationContext context)
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
                throw new FraException($"An error occurred during {nameof(IFraModule.PreConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        private void InvokeConfigureServices(ServiceConfigurationContext context)
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
                throw new FraException($"An error occurred during {nameof(IFraModule.ConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        private void InvokePostConfigureServices(ServiceConfigurationContext context)
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
                throw new FraException($"An error occurred during {nameof(IFraModule.PostConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        public virtual void ShutDown()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
