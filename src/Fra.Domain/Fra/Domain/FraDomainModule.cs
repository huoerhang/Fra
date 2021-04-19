using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Fra.Modularity;
using Fra.Domain.Entities;

namespace Fra.Domain
{
    public class FraDomainModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IEntityEqualizerContainer, EntityEqualizerContainer>();
        }
    }
}
