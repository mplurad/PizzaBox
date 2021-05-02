using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class Order
    {
        public Order()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
