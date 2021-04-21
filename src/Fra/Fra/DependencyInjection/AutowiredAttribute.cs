using AspectCore.DependencyInjection;
using System;

namespace Fra.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AutowiredAttribute : FromServiceContextAttribute
    {
    }
}
