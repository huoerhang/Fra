using System;

namespace Fra.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class AutowiredAttribute : Attribute
    {

    }
}
