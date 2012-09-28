using Billboards.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billboards.Common.Service
{
    public interface ILocationsService : IEnumerable<LocationModel>
    {
        void Save();

        Task<bool> SeAsUnAvailableAsync(string id);

        bool SetAsUnAvailable(string id);
        
        Task<bool> SeAsTemporaryUnAvailableAsync(string locationId);

        bool SetAsTemporaryUnAvailable(string locationId);

        Task<bool> SeAsTemporaryAvailableAsync(string locationId);

        bool SeAsTemporaryAvailable(string locationId);
   
    }
}
