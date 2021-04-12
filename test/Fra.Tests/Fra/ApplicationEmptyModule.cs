using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra.Modularity;

namespace Fra.Tests.Fra
{
    public class ApplicationEmptyModule : AppModule, IAppEntryModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            Console.WriteLine($"{nameof(ApplicationEmptyModule.PreConfigureServices)}");
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Console.WriteLine($"{nameof(ApplicationEmptyModule.ConfigureServices)}");
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            Console.WriteLine($"{nameof(ApplicationEmptyModule.PostConfigureServices)}");
        }
    }
}
