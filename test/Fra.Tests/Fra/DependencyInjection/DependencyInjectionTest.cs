﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fra.Tests.DependencyInjection
{
    public class DependencyInjectionTest
    {
        [Fact]
        public void Should_DependencyInjection_Class()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddApplication<ApplicationEmptyModule>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var cat= serviceProvider.GetService<ICat>();
            cat.Eat();
            var dog = serviceProvider.GetService<IDog>();
            dog.Eat();
            var tigger = serviceProvider.GetService<Tigger>();
            tigger.Eat();
        }
    }
}
