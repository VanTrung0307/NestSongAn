using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessObjects.Entity
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
