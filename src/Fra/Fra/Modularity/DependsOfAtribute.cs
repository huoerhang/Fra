using System;

namespace Fra.Modularity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOfAtribute : Attribute, IDependedTypesProvider
    {
        private readonly Type[] _dependendTypes;

        public DependsOfAtribute(params Type[] dependedTypes)
        {
            _dependendTypes = dependedTypes ?? new Type[0];
        }

        public Type[] GetDependedTypes()
        {
            return _dependendTypes;
        }
    }
}
