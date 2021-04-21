using AspectCore.Extensions.DependencyInjection;
using Fra.Modularity;

namespace Fra
{
    public class FraAspectCoreAppModule : AppModule
    {
        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.ConfigureDynamicProxy();
        }
    }
}
