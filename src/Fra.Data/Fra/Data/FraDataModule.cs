using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra.Domain;
using Fra.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.Data
{
    [Depends(typeof(FraDomainModule))]
    public class FraDataModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddSingleton(typeof(IDataFilter<>), typeof(DataFilter<>));
        }
    }
}
