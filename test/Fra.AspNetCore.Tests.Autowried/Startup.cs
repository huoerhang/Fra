using AspectCore.Extensions.DependencyInjection;
using Fra.AspNetCore.Tests.Autowried.Repositories;
using Fra.AspNetCore.Tests.Autowried.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Console;
using Fra.Modularity;

namespace Fra.AspNetCore.Tests.Autowried
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ILogger,ConsoleLoggerExtensions.>
            //services.AddLogging();
            //services.AddTransient<IWeatherForecastServices, WeatherForecastServices>();
            //services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
            //services.AddControllers().AddControllersAsServices();
            //services.ConfigureDynamicProxy();

            //foreach (var item in services)
            //{
            //    Console.WriteLine(item.ImplementationType);
            //}
            services.AddApplication<FraAspNetCoreTestModule>();
            foreach(var  name in this.GetType().Assembly.GetReferencedAssemblies())
            {
                Assembly assembly = Assembly.Load(name);
                foreach(var referAss in assembly.GetReferencedAssemblies())
                {
                    Console.WriteLine("\t"+referAss.Name);
                }

                //foreach(var type in  assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo<IAppModule>()))
                //{
                //    Console.WriteLine(type.AssemblyQualifiedName);
                //}
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeApplication();

            //            var app = context.GetApplicationBuilder();
            //          var env = context.GetEnvironment();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
