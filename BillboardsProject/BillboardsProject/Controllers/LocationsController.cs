using Billboards.Common.Models;
using Billboards.Common.Service;
using BillboardsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillboardsProject.Controllers
{
    public class LocationsController : Controller
    {
        ILocationsService _locationService;

        public LocationsController()
        {
            Console.WriteLine("LocationsController was created");
            _locationService = new LocationService();
        }

        public ActionResult ShowAll()
        {

            List<LocationViewModel> locations = new List<LocationViewModel>();
            foreach (var item in _locationService)
            {
                locations.Add(new LocationViewModel(item));

            }

            return View(locations);
        }

        public ActionResult Buy(LocationModel location)
        {
            return View(location);
        }
    }
}
