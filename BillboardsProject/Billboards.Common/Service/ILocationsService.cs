using Billboards.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Service
{
    public interface ILocationsService : IEnumerable<LocationModel>
    {
        void Save();        
    }
}
