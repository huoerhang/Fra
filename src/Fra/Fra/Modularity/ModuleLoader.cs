using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Modularity
{
    internal class ModuleLoader
    {
        public AppModuleDescriptor[] LoadModules(IServiceCollection services, Type appEntryModuleType)
        {
            services.CheckNotNull(nameof(services));
            appEntryModuleType.CheckEntryModuleType();
            var descriptors = GetAppModuleDescriptors(services, appEntryModuleType);
            var sortedDescriptors = SortByDependency(descriptors, appEntryModuleType);

            return sortedDescriptors.ToArray();
        }

        private List<AppModuleDescriptor> SortByDependency(List<AppModuleDescriptor> descriptors, Type appEntryModuleType)
        {
            var sorted = descriptors.SortByDependencies(c => c.Dependencies);
            sorted.MoveItem(c => c.ModuleType == appEntryModuleType, descriptors.Count - 1);

            return sorted;
        }

        private List<AppModuleDescriptor> GetAppModuleDescriptors(IServiceCollection services, Type appEntryModule)
        {
            var appModuleDescriptors = new List<AppModuleDescriptor>();
            FillModules(services, appEntryModule, appModuleDescriptors);
            SetDependencies(appModuleDescriptors);

            return appModuleDescriptors;
        }

        private void FillModules(IServiceCollection services, Type appEntryModule, List<AppModuleDescriptor> appModuleDescriptors)
        {
            foreach (var moduleType in AppModuleHelper.FindAllModuleTypes(appEntryModule))
            {
                var moduleDescriptor = CreateModuleDescriptor(services, moduleType);
                appModuleDescriptors.Add(moduleDescriptor);
            }
        }

        private void SetDependencies(List<AppModuleDescriptor> appModuleDescriptors)
        {
            foreach (var descriptor in appModuleDescriptors)
            {
                SetDependencies(descriptor, appModuleDescriptors);
            }
        }

        private AppModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType)
        {
            var module = CreateAndRegisterModule(services, moduleType);

            return new AppModuleDescriptor(module);
        }

        private IAppModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
        {
            var module = (IAppModule)Activator.CreateInstance(moduleType);
            services.AddSingleton(moduleType, module);

            return module;
        }

        private void SetDependencies(AppModuleDescriptor appModuleDescriptor, List<AppModuleDescriptor> appModuleDescriptors)
        {
            var moduleType = appModuleDescriptor.ModuleType;

            foreach (var dependedModuleType in AppModuleHelper.FindDependedModuleTypes(moduleType))
            {
                var depended = appModuleDescriptors.FirstOrDefault(c => c.ModuleType == dependedModuleType);

                if (depended == null)
                {
                    throw new FraException($"Could not found a depended module {dependedModuleType.AssemblyQualifiedName} ");
                }

                appModuleDescriptor.AddDepoendency(depended);
            }
        }
    }
}
