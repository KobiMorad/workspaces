using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Service
{
    public interface IServiceLocator
    {
        TContract GetService<TContract>() where TContract : class;
    }

    public class LocalServiceLocator : IServiceLocator
    {

        Dictionary<string, object> _objects
            = new Dictionary<string, object>();

        public LocalServiceLocator()
        {
            var locationService = new Service.LocationService();
            var paymentService = new Service.PaymentService();
            var billboardService = new Service.Billboard.BillboardService();
            var ordersService = new Service.OrdersService(locationService, paymentService);

            _objects.Add(typeof(IBillboardsService).FullName, billboardService);
            _objects.Add(typeof(ILocationsService).FullName, locationService);

            _objects.Add(typeof(IPaymentService).FullName, paymentService);

            _objects.Add(typeof(IOrdersService).FullName, ordersService);
        }



        public TContract GetService<TContract>() where TContract : class
        {
            object value;
            _objects.TryGetValue(typeof(TContract).FullName, out value);

            return value as TContract;
        }
    }

    public static class ServiceLocator
    {
        public static IServiceLocator Current { get; private set; }

        static ServiceLocator()
        {
            Current = new LocalServiceLocator();
        }

    }


}
