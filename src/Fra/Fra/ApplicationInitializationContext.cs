using System;

namespace Fra
{
    public class ApplicationInitializationContext: ApplicationLifecycleContenxt
    {
        public ApplicationInitializationContext(IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
        }
    }
}
