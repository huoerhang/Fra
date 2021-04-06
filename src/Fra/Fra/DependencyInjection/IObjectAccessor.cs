using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.DependencyInjection
{
    public interface IObjectAccessor<out T>
    {
        T Value { get; }
    }
}
