using System;

namespace Fra.Modularity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAtribute : Attribute, IDependedTypesProvider
    {
        private readonly Type[] _dependendTypes;

        public DependsOnAtribute(params Type[] dependedTypes)
        {
            _dependendTypes = dependedTypes ?? new Type[0];
        }

        public Type[] GetDependedTypes()
        {
            return _dependendTypes;
        }
    }
}
