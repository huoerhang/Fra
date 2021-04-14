using Fra.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Tests.DependencyInjection
{
    [Dependency(IncludeSelf = true)]
    public class Tigger
    {
        public void Eat()
        {
            Console.WriteLine("喵哈哈");
        }
    }
}
