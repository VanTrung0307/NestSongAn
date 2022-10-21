using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessObjects.Entity
{
    public partial class Shop
    {
        public Shop()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
