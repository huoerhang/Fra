using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Modularity
{
    public interface IApplicationShutdownModuleContributor
    {
        void OnApplicationShutdown(ApplicationShutdownContext context);
    }
}
