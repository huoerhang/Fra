using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Ddd.Domain
{
    public static class TypeExtensions
    {
        public static bool IsEntity(this Type type)
        {
            return type.IsAssignableTo<IEntity>();
        }
    }
}
