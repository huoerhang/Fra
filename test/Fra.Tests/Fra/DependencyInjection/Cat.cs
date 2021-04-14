using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fra.DependencyInjection;

namespace Fra.Tests.DependencyInjection
{
    public interface ICat
    {
        void Eat();
    }

    [Dependency()]
    public class Cat : ICat
    {
        private readonly IDog _dog;

        public Cat(IDog dog)
        {
            _dog=dog;
        }

        public void Eat()
        {
            _dog.Eat();
            Console.WriteLine("喵喵");
        }
    }
}
