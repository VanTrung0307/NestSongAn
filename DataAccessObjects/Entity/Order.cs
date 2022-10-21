using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessObjects.Entity
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public double TotalAmount { get; set; }
        public double? Discount { get; set; }
        public double? DiscountOrderDetail { get; set; }
        public double FinalAmount { get; set; }
        public int OrderStatus { get; set; }
        public string ApprovePerson { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public int DeliveryStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
