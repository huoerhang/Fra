using System;
using Fra.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Fra
{
    public interface IApplication : IModuleContainer, IDisposable
    {
        Type EntryModuleType { get; }

        IServiceCollection Services { get; }

        IServiceProvider ServiceProvider { get; }

        void ShutDown();
    }
}
