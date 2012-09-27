
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Service
{
    public interface IBillboardsService : IEnumerable<Models.Billboard>
    {
        void Add(Models.Billboard billborad);
        void Remove(string id);
    }
}
