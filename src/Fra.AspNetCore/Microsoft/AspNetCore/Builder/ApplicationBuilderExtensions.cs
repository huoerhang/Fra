using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra;
using Fra.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void InitializeApplication(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var objectAccessor = serviceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>();
            var application = serviceProvider.GetRequiredService<IApplication>();
            objectAccessor.Value = serviceProvider;
            var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            applicationLifetime.ApplicationStarted.Register(() =>
            {

            });

            applicationLifetime.ApplicationStopping.Register(() =>
            {
                application.ShutDown();
            });
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                application.Dispose();
            });

            application.Initialize();
        }
    }
}
