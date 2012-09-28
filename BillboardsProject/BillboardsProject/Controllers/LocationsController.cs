using System.Collections.Generic;
using System.Threading.Tasks;
using Billboards.Common.Models;
using Billboards.Common.Service;
using BillboardsProject.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BillboardsProject.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationsService _locationService;
        private IOrdersService _ordersService;

        public LocationsController()
        {
            Console.WriteLine("LocationsController was created");
            _locationService = ServiceLocator.Current.GetService<ILocationsService>();
            _ordersService = ServiceLocator.Current.GetService<IOrdersService>();
        }

        public ActionResult ShowAll()
        {
            var locations =
                _locationService.Where(p => p.IsAvailable).Select(item => new LocationViewModel(item)).ToList();
            return View(locations);
        }


        public ActionResult ShowLocationInfo(LocationViewModel locationViewModel)
        {
            return View(locationViewModel);
        }

        public async Task<ActionResult> Buy(LocationModel location)
        {
            if (ModelState.IsValid)
            {
                var name = User.Identity.Name;
                var succuess = await _ordersService.OrderAsync(name);
                return RedirectToAction("ShowAll");
            }
            return View(location);
        }

        [Authorize]
        public async Task<ActionResult> AddToCart(LocationViewModel location)
        {
            if (ModelState.IsValid)
            {
                var name = User.Identity.Name;
                var succuess =
                    await
                    _ordersService.AddToCartAsync(name, location.Id,
                                                  new OrderDetail()
                                                      {Start = DateTime.Now, End = DateTime.Now + TimeSpan.FromDays(10)});
                return RedirectToAction("ShowAll");
            }   
            return null;
        }


        public ActionResult Cart()
        {
            if (ModelState.IsValid)
            {
                var name = User.Identity.Name;
                List<OrderDetail> carts;
                if (_ordersService.TryGetCartForUser(name, out carts))
                {
                    IEnumerable<KeyValuePair<OrderDetailViewModel, LocationViewModel>> orderDetailViewModels =
                        carts.Select(orderDetail =>
                            {
                                var orderDetailViewModel = new OrderDetailViewModel(orderDetail);
                                var firstOrDefault = _locationService.FirstOrDefault(p => p.Id == orderDetail.LocationId);

                                return new KeyValuePair<OrderDetailViewModel, LocationViewModel>(orderDetailViewModel,
                                                                                                 new LocationViewModel(
                                                                                                     firstOrDefault));
                            });

                    return View(orderDetailViewModels);
                }
                return RedirectToAction("ShowAll");
            }
            return null;
        }

        public ActionResult RemoveFromCart(string id)
        {
            _ordersService.RemoveFromCart(string.Empty);
            if (ModelState.IsValid)
            {
                var name = User.Identity.Name;
                List<OrderDetail> carts;
                IEnumerable<KeyValuePair<OrderDetailViewModel, LocationViewModel>> orderDetailViewModels;

                orderDetailViewModels = new List<KeyValuePair<OrderDetailViewModel, LocationViewModel>>();

                return View("Cart", orderDetailViewModels);

            }
            return null;

        }

        public ActionResult AllOrders()
        {
            var ordersService = _ordersService;
            return View(ordersService);
        }
    }
 
}
