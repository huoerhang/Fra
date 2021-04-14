using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Fra;
using Microsoft.Extensions.DependencyInjection;

namespace Fra.Tests.DependencyInjection
{
    public class Application_Tests
    {
        [Fact]
        public void Should_Initialize_Single_Module()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddApplication<ApplicationEmptyModule>();
        }
    }
}
