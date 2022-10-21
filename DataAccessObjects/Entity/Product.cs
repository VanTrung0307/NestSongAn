using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessObjects.Entity
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string PicUrl { get; set; }
        public int StockId { get; set; }
        public int QuantityInStock { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
