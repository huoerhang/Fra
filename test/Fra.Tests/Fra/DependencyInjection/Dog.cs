using Fra.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Tests.DependencyInjection
{
    public interface IDog
    {
        void Eat();
    }

    [Dependency()]
    public class Dog : IDog
    {
        public void Eat()
        {
            Console.WriteLine("旺旺");
        }
    }
}
