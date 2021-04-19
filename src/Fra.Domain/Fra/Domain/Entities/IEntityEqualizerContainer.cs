using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Domain.Entities
{
    public interface IEntityEqualizerContainer:IList<IEntityEqualizer>
    {
        bool EntityEquals(IEntity self, IEntity other);
    }
}
