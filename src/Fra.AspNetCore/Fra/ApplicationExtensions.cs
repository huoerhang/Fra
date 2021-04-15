using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Fra
{
    public static class ApplicationExtensions
    {
        public static void SetServiceProvider(this IApplication application,IServiceProvider serviceProvider)
        {
            //application.Services.AddObjectInstance<>
        }
    }
}
