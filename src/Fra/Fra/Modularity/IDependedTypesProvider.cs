using System;

namespace Fra.Modularity
{
    public interface IDependedTypesProvider
    {
        Type[] GetDependedTypes();
    }
}
