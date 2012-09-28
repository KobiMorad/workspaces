using System.Collections.Generic;
using System.Threading.Tasks;
using Billboards.Common.Models;

namespace Billboards.Common.Service
{
    public interface IOrdersService : IEnumerable<KeyValuePair<OrderModel, List<OrderDetail>>>
    {
        Task<bool> OrderAsync(string userId);
        Task<bool> AddToCartAsync(string userId, string location, IOrderInfo orderInfo);
        Task<bool> RemoveFromCartAsync(string userId, string locationId);

        bool RemoveFromCart(string userId, string locationId = null);
        bool TryGetCartForUser(string userId, out List<OrderDetail> cartOrders);

        
    }
}