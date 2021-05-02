using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class AStore
    {
        public AStore()
        {
            Orders = new HashSet<AOrder>();
        }

        public int StoreId { get; set; }
        public string StoreLocation { get; set; }

        public virtual ICollection<AOrder> Orders { get; set; }

        public override string ToString()
        {
            return StoreLocation;
        }
    }
}
