using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreLocation { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return StoreLocation;
        }
    }
}