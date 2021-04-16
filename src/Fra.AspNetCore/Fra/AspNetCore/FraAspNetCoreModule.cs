using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fra.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.AspNetCore
{
    public class FraAspNetCoreModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AddAspNetServices(context.Services);
            context.Services.AddObjectAccessor<IApplicationBuilder>();
        }

        private static void AddAspNetServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
    }
}
