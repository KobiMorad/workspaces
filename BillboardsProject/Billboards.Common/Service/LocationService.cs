using Billboards.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Service
{
    public class LocationService : ILocationsService
    {
        public List<LocationModel> _locations;

        public LocationService()
        {
            _locations = new List<LocationModel>();

            InitializeLocations();

        }

        private void InitializeLocations()
        {
            _locations.Add(new LocationModel() { Id = "dfds", Position = new LLA(31.4, 29.3), Discription = "this is the first location", IsAvailable = true ,PricePerDay = 49.99});
            _locations.Add(new LocationModel() { Id = "fdsf", Position = new LLA(32.4, 31.3), Discription = "this location is most poppler for business man", IsAvailable = true,PricePerDay = 0.99});
            _locations.Add(new LocationModel() { Id = "sfsdfsd", Position = new LLA(33.4, 55.3), Discription = "this location is most poppler for womens", IsAvailable = true, PricePerDay = 100 });
            _locations.Add(new LocationModel() { Id = "Sdfdsf", Position = new LLA(34.4, 31.3), Discription = "temp ", IsAvailable = true, PricePerDay = 5.99});
            _locations.Add(new LocationModel() { Id = "DSfds", Position = new LLA(35.4, 31.3), Discription = "this is the first location ", IsAvailable = true, PricePerDay = 4.99 });

        }

        public void Save()
        {

        }

        public Task<bool> SeAsUnAvailableAsync(string locationId)
        {
            return Task.Run(() => SetAsUnAvailable(locationId));            
        }

        public bool SetAsUnAvailable(string locationId)
        {
            var location = _locations.FirstOrDefault(p => p.Id == locationId);
            if (location == null) return false;
            if (location.InLockState == false) return false;
            
            if (location.IsAvailable == false) return false;

            location.IsAvailable = false;
            location.InLockState = false;
            return true;
        }

        public Task<bool> SeAsTemporaryUnAvailableAsync(string locationId)
        {      
           return Task.Run(() => SetAsTemporaryUnAvailable(locationId));                        
        }

        public bool SetAsTemporaryUnAvailable(string locationId)
        {
            var location = _locations.FirstOrDefault(p => p.Id == locationId);
            if (location != null)
            {
                location.InLockState = true;
                return true;
            }
            return false;
        }

        public Task<bool> SeAsTemporaryAvailableAsync(string locationId)
        {          
            return Task.Run(() => SeAsTemporaryAvailable(locationId));
        }

        public bool SeAsTemporaryAvailable(string locationId)
        {
            var location = _locations.FirstOrDefault(p => p.Id == locationId);
            if (location != null)
            {
                location.InLockState = false;
                return true;
            }
            return false;
        }

        public IEnumerator<LocationModel> GetEnumerator()
        {
            return _locations.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _locations.GetEnumerator();
        }
    }
}
