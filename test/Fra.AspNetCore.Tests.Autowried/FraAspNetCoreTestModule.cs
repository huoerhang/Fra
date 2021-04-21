using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fra.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fra.AspNetCore.Tests.Autowried
{
    [Depends(typeof(FraAspNetCoreModule))]
    public class FraAspNetCoreTestModule : AppModule, IAppEntryModule, IApplicationInitializationModuleContributor
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddControllers();
        }

        public void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
