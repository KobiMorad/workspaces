using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billboards.Common.Models;

namespace Billboards.Common.Service
{
    public interface IPaymentService
    {
        Task<string> Pay(double price);
    }

    public class PaymentService : IPaymentService
    {
        public Task<string> Pay(double price)
        {
            return Task.Run(() =>
                {
                    var authorizationKey = Guid.NewGuid().ToString();
                    return authorizationKey;
                });

        }
    }
}
