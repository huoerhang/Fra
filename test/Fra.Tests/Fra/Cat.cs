using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra.DependencyInjection;

namespace Fra.Tests.Fra
{
    public interface ICat
    {
        void Eat();
    }

    [Dependency()]
    public class Cat : ICat
    {
        public void Eat()
        {
            Console.WriteLine("喵喵");
        }
    }
}
