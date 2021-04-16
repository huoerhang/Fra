using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fra.Modularity;
using Fra.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace Fra.AspNet.Tests
{
    [Depends(typeof(FraAspNetCoreModule))]
    public class FraAspNetCoreTestModule : AppModule, IAppEntryModule, IApplicationLifecycleModuleContributor
    {
        public void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {
            Console.WriteLine("OnPreApplicationInitialization");
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            Console.WriteLine("OnApplicationInitialization");
        }

        public void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {
            Console.WriteLine("OnPostApplicationInitialization");
        }

        public void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            Console.WriteLine("OnApplicationShutdown");
        }
    }
}
