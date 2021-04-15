using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra.Guids;
using Fra.Modularity;

namespace Fra.Tests.Guids
{
    public class GuidsTestEmptyAppModule : AppModule, IAppEntryModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<SequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAtEnd;
            });
        }
    }
}
