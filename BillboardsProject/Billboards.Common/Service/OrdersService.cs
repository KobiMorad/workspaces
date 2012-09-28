using System;
using System.Collections;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billboards.Common.Models;

namespace Billboards.Common.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly ILocationsService _locationsService;
        private readonly IPaymentService _paymentService;
        private readonly ConcurrentDictionary<OrderModel, List<OrderDetail>> _orders;

        private readonly ConcurrentDictionary<string, List<OrderDetail>> _carts;

        public OrdersService(ILocationsService locationsService, IPaymentService paymentService)
        {
            _orders = new ConcurrentDictionary<OrderModel, List<OrderDetail>>();
            _locationsService = locationsService;
            _paymentService = paymentService;
            _carts = new ConcurrentDictionary<string, List<OrderDetail>>();
        }

        public Task<bool> AddToCartAsync(string userId, string locationid, IOrderInfo orderInfo)
        {
            return Task.Run(() => AddToChart(userId, locationid, orderInfo));
        }

        private bool AddToChart(string userId, string locationid, IOrderInfo orderInfo)
        {
            var location = _locationsService.FirstOrDefault(p => p.Id == locationid);
            if (location == null) return false;

            try
            {
                _carts.AddOrUpdate(userId, user =>
                    {
                        var orderDetailModels = CreateOrderDetailModels(user, location, orderInfo);
                        return new List<OrderDetail>() { orderDetailModels };
                    }, (user, orderDetails) =>
                        {
                            orderDetails.Add(CreateOrderDetailModels(user, location, orderInfo));
                            return orderDetails;
                        });
            }
            catch (Exception e)
            {
                return false;

            }

            return true;
        }

        private OrderDetail CreateOrderDetailModels(string user, LocationModel location, IOrderInfo orderInfo)
        {

            //set user as the id for this order until this order move from cart;
            if (location.IsAvailable && location.InLockState == false)
            {
                if (_locationsService.SetAsTemporaryUnAvailable(location.Id))
                {
                    var orderDetailModels = new OrderDetail { OrderId = user };

                    double totalDays = Math.Abs((orderInfo.Start - orderInfo.End).TotalDays);

                    orderDetailModels.Start = orderInfo.Start;
                    orderDetailModels.End = orderInfo.End;
                    orderDetailModels.LocationId = location.Id;
                    orderDetailModels.Total = totalDays * location.PricePerDay;

                    return orderDetailModels;
                }
            }
            throw new Exception("Could't create order");

        }

        public Task<bool> RemoveFromCartAsync(string userId, string locationId)
        {
            return Task.Run(() => RemoveFromCart(userId, locationId));
        }

        public bool RemoveFromCart(string userId, string locationId = null)
        {
            List<OrderDetail> userOrders;

            if (_carts.TryGetValue(userId, out userOrders))
            {
                var wasRemoved = false;
                try
                {
                    if (string.IsNullOrEmpty(locationId))
                    {
                        RemoveFromUserFromCart(userId, out userOrders);
                        wasRemoved = true;
                    }


                    var firstOrDefault = userOrders.FirstOrDefault(p => p.LocationId == locationId);
                    if (firstOrDefault != null)
                    {
                        wasRemoved = userOrders.Remove(firstOrDefault);
                    }

                    if (userOrders.Count == 0)
                    {
                        RemoveFromUserFromCart(userId, out userOrders);
                    }
                }
                finally
                {
                    if (userOrders != null)
                    {
                        userOrders.ForEach(p => _locationsService.SeAsTemporaryAvailable(p.LocationId));
                    }
                }

                return wasRemoved;

            }

            return false;
        }

        public bool RemoveFromUserFromCart(string userId, out List<OrderDetail> userOrders)
        {
            var removeFromUserFromCart = _carts.TryRemove(userId, out userOrders);
            return removeFromUserFromCart;
        }

        public bool TryGetCartForUser(string userId, out List<OrderDetail> cartOrders)
        {
            return _carts.TryGetValue(userId, out cartOrders);
        }

        public Task<bool> OrderAsync(string userId)
        {

            var task = Task.Run(async () =>
                {
                    List<OrderDetail> userOrders;

                    if (RemoveFromUserFromCart(userId, out userOrders) == false) return false;

                    var orderId = Guid.NewGuid().ToString();

                    var orderModel = new OrderModel { OrderId = orderId, UserId = userId, OrderDate = DateTime.Now };

                    var total = userOrders.Sum(p => p.Total);
                    userOrders.ForEach(p => p.OrderId = orderId);




                    var payTask = await _paymentService.Pay(total);


                    if (string.IsNullOrEmpty(payTask) == true)
                    {
                        //return order to cart;
                        //cancle order
                    }

                    var addOrderTask = await AddOrder(orderModel, userOrders);
                    if (addOrderTask == true)
                    {
                        var locations = userOrders.Select(p => p.LocationId);
                        foreach (var location in locations)
                        {
                            _locationsService.SetAsUnAvailable(location);
                        }
                        return true;
                    }

                    return false;
                });

            return task;
        }

        private Task<bool> AddOrder(OrderModel orderModel, List<OrderDetail> userOrders)
        {
            return Task.Run(() => _orders.TryAdd(orderModel, userOrders));
        }

        public IEnumerator<KeyValuePair<OrderModel, List<OrderDetail>>> GetEnumerator()
        {
            var enumerator = this._orders.GetEnumerator();
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
