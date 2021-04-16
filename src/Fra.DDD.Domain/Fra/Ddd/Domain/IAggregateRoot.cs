using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Ddd.Domain
{
    public interface IAggregateRoot : IEntity
    {
    }

    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {

    }
}
