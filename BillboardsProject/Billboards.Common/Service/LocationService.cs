using Billboards.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Service
{
    public class LocationService : ILocationsService
    {
        public List<LocationModel> Locations;

        public LocationService()
        {
            Locations = new List<LocationModel>();

            InitializeLocations();


        }

        private void InitializeLocations()
        {
            Locations.Add(new LocationModel (){Id=0,Position= new LLA (31.4,29.3),Discription="this is the first location"});
            Locations.Add(new LocationModel (){Id=1,Position= new LLA (32.4,31.3),Discription="this location is most poppler for business man"});
            Locations.Add(new LocationModel() { Id = 2, Position = new LLA(33.4, 55.3), Discription = "this location is most poppler for womens" });
            Locations.Add(new LocationModel (){Id=3,Position= new LLA (34.4,31.3),Discription="temp "});
            Locations.Add(new LocationModel (){Id=4,Position= new LLA (35.4,31.3),Discription="this is the first location "});
                
        }

        public void Save()
        {

        }

        public System.Collections.Generic.IEnumerator<Models.LocationModel> GetEnumerator()
        {
            return Locations.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Locations.GetEnumerator();
        }
    }
}
