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
        private readonly IReadOnlyCollection<AppModuleDescriptor> _moduleDescriptors;
        private IReadOnlyCollection<IApplicationPreInitializationModuleContributor>? _preInitializationModules;
        private IReadOnlyCollection<IApplicationInitializationModuleContributor>? _initializationModules;
        private IReadOnlyCollection<IApplicationPostInitializationModuleContributor>? _postInitializationModules;
        private IReadOnlyCollection<IApplicationShutdownModuleContributor>? _shutDownModules;

        public ModuleManager(IModuleContainer moduleContainer, ILogger<ModuleManager> logger)
        {
            _moduleContainer = moduleContainer;
            _logger = logger;
            _moduleDescriptors = moduleContainer.Modules;
            FillLifecycleModules();
        }

        public void InitializeModules(ApplicationInitializationContext context)
        {
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
            if (_shutDownModules == null)
            {
                return;
            }

            var reverseDescriptors = _shutDownModules.Reverse().ToList();

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
            ExecuteInitialization(_preInitializationModules, modules =>
            {
                foreach (var item in modules)
                {
                    item.OnPreApplicationInitialization(context);
                }
            });
        }

        private void ExecuteApplicationInitialization(ApplicationInitializationContext context)
        {
            ExecuteInitialization(_initializationModules, modules =>
            {
                foreach (var item in modules)
                {
                    item.OnApplicationInitialization(context);
                }
            });
        }

        private void ExecutePostApplicationInitialization(ApplicationInitializationContext context)
        {
            ExecuteInitialization(_postInitializationModules, modules =>
             {
                 foreach (var item in modules)
                 {
                     item.OnPostApplicationInitialization(context);
                 }
             });
        }

        private void ExecuteInitialization<T>(IReadOnlyCollection<T>? modules, Action<IReadOnlyCollection<T>> action)
        {
            if (modules == null)
            {
                return;
            }

            action(modules);
        }

        private void FillLifecycleModules()
        {
            _preInitializationModules = LifecycleModulesFilter<IApplicationPreInitializationModuleContributor>();
            _initializationModules = LifecycleModulesFilter<IApplicationInitializationModuleContributor>();
            _postInitializationModules = LifecycleModulesFilter<IApplicationPostInitializationModuleContributor>();
            _shutDownModules = LifecycleModulesFilter<IApplicationShutdownModuleContributor>();
        }

        private IReadOnlyCollection<T> LifecycleModulesFilter<T>()
        {
            return _moduleDescriptors.Where(c => c.ModuleType.IsAssignableTo<T>()).Select(c=>c.Instance)
                 .Cast<T>().ToImmutableList();
        }
    }
}
