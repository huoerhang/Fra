using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Domain.Entities
{
    public class EntityEqualizerContainer : List<IEntityEqualizer>, IEntityEqualizerContainer
    {
        public bool EntityEquals(IEntity self, IEntity other)
        {

        }
    }
}
