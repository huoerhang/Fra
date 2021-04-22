using Microsoft.Extensions.DependencyInjection;
using Fra.Modularity;
using Fra.Domain.Entities;
using Fra.DependencyInjection;

namespace Fra.Domain
{
    public class FraDomainModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddObjectAccessor(new ObjectAccessor<EntityEqualizerContainer>());
        }
    }
}
