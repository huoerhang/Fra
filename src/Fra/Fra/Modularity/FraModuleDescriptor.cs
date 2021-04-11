using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Fra.Modularity
{
    public class FraModuleDescriptor
    {
        private readonly List<FraModuleDescriptor> _dependencies;

        internal FraModuleDescriptor(IFraModule instance)
        {
            ModuleType = instance.GetType();
            Assembly = ModuleType.Assembly;
            Instance = instance;

            _dependencies = new List<FraModuleDescriptor>();
        }

        public Assembly Assembly { get; }

        public Type ModuleType { get; }

        public IFraModule Instance { get; }

        public IReadOnlyCollection<FraModuleDescriptor> Dependencies => _dependencies.ToImmutableList();

        public void AddDepoendency(FraModuleDescriptor appModuleDescriptor)
        {
            _dependencies.Add(appModuleDescriptor);
        }
    }
}
