using System;

namespace Fra
{
    public class ApplicationLifecycleContenxt
    {
        public IServiceProvider ServiceProvider { get; }

        public ApplicationLifecycleContenxt(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
