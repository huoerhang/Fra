using System.Collections.Generic;

namespace Fra.Modularity
{
    public interface IModuleContainer
    {
        IReadOnlyCollection<FraModuleDescriptor> Modules { get; }
    }
}
