using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using Fra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fra.Modularity
{
    [Dependency(ServiceLifetime.Singleton)]
    public class ModuleManager : IModuleManager
    {
        private readonly IModuleContainer _moduleContainer;
        private readonly ILogger<ModuleManager> _logger;
        private readonly IReadOnlyCollection<AppModuleDescriptor> _moduleDescriptors;// _lifecycleModules; //= new List<AppModuleDescriptor>();
        private IReadOnlyCollection<IApplicationLifecycleModuleContributor> _lifecycleModules;

        public ModuleManager(IModuleContainer moduleContainer, ILogger<ModuleManager> logger)
        {
            _moduleContainer = moduleContainer;
            _logger = logger;
            _moduleDescriptors = moduleContainer.Modules;
            _lifecycleModules = LifecycleModulesFilter(moduleContainer.Modules);
        }

        public void InitializeModules(ApplicationInitializationContext context)
        {
            if (_lifecycleModules == null)
            {
                return;
            }

            try
            {
                ExecutePreApplicationInitialization(context);
                ExecuteApplicationInitialization(context);
                ExecutePostApplicationInitialization(context);
            }
            catch
            {
                throw;
            }

            _logger.LogInformation("Initialized all AppModules.");
        }

        public void ShutdownModules(ApplicationShutdownContext context)
        {
            var reverseDescriptors = _lifecycleModules.Reverse().ToList();

            try
            {
                foreach (var item in reverseDescriptors)
                {
                    item.OnApplicationShutdown(context);
                }
            }
            catch
            {
                throw;
            }
        }

        private void ExecutePreApplicationInitialization(ApplicationInitializationContext context)
        {
            foreach (var item in _lifecycleModules)
            {
                item.OnPreApplicationInitialization(context);
            }
        }

        private void ExecuteApplicationInitialization(ApplicationInitializationContext context)
        {
            foreach (var item in _lifecycleModules)
            {
                item.OnApplicationInitialization(context);
            }
        }

        private void ExecutePostApplicationInitialization(ApplicationInitializationContext context)
        {
            foreach (var item in _lifecycleModules)
            {
                item.OnPostApplicationInitialization(context);
            }
        }

        private IReadOnlyCollection<IApplicationLifecycleModuleContributor> LifecycleModulesFilter(IEnumerable<AppModuleDescriptor> modules)
        {
            return modules.Where(c => c.ModuleType.IsAssignableTo<IApplicationLifecycleModuleContributor>())
                 .Cast<IApplicationLifecycleModuleContributor>().ToImmutableList();
        }
    }
}
