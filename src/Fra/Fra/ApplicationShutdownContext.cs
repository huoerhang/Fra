using System;

namespace Fra
{
    public class ApplicationShutdownContext : ApplicationLifecycleContenxt
    {
        public ApplicationShutdownContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
