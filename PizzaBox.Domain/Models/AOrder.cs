using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class AOrder
    {
        public AOrder()
        {
            Pizzas = new HashSet<APizza>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual ACustomer Customer { get; set; }
        public virtual AStore Store { get; set; }
        public virtual ICollection<APizza> Pizzas { get; set; }
    }
}
