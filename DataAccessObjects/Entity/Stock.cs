using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessObjects.Entity
{
    public partial class Stock
    {
        public Stock()
        {
            InverseGrandStock = new HashSet<Stock>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int? ShopId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int? GrandStockId { get; set; }

        public virtual Stock GrandStock { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Stock> InverseGrandStock { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
