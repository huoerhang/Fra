using System.Collections.Generic;

namespace Fra.Modularity
{
    public interface IModuleContainer
    {
        IReadOnlyCollection<AppModuleDescriptor> Modules { get; }
    }
}
