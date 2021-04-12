using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Fra.Modularity
{
    public class AppModuleDescriptor
    {
        private readonly List<AppModuleDescriptor> _dependencies;

        internal AppModuleDescriptor(IAppModule instance)
        {
            ModuleType = instance.GetType();
            Assembly = ModuleType.Assembly;
            Instance = instance;

            _dependencies = new List<AppModuleDescriptor>();
        }

        public Assembly Assembly { get; }

        public Type ModuleType { get; }

        public IAppModule Instance { get; }

        public IReadOnlyCollection<AppModuleDescriptor> Dependencies => _dependencies.ToImmutableList();

        public void AddDepoendency(AppModuleDescriptor appModuleDescriptor)
        {
            _dependencies.Add(appModuleDescriptor);
        }
    }
}
