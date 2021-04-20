using System;

namespace Fra.Data
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConnectionStringNameAttribute : Attribute
    {
        public string Name { get; }

        public ConnectionStringNameAttribute(string name)
        {
            name.CheckNotNull(nameof(name));
            Name = name;
        }
    }
}
