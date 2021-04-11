using System.Collections.Generic;

namespace Fra.Modularity
{
    public interface IModuleContainer
    {
        List<AppModuleDescriptor> AppModules { get; }
    }
}
