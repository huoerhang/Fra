using Fra.Guids;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fra.Tests.Guids
{
    public class GuidsTest
    {
        [Fact]
        public void Should_Guid_Created()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddApplication<GuidsTestEmptyAppModule>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var guidProvider = serviceProvider.GetService<IGuidProvider>();
            var guid = guidProvider.Create();
            var myServiceProvider = serviceProvider.GetService<IServiceProvider>();
        }
    }
}
