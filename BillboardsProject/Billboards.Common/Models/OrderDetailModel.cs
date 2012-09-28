using System;

namespace Billboards.Common.Models
{

    public class OrderModel : IEquatable<OrderModel>
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }


        public bool Equals(OrderModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(OrderId, other.OrderId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderModel) obj);
        }

        public override int GetHashCode()
        {
            return (OrderId != null ? OrderId.GetHashCode() : 0);
        }

       
     
    }

    public interface IOrderInfo
    {
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }

    public class OrderDetail : IOrderInfo
    {
        public string OrderId { get; set; }
        public string LocationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Total { get; set; }
    }
}
