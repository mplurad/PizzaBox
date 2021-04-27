using System;
namespace PizzaBox.Client.Models
{
    public class Store
    {
        public Store()
        {
            //Orders = new HashSet<AOrder>();
        }

        public byte StoreId { get; set; }
        public string StoreLocation { get; set; }

        //public virtual ICollection<AOrder> Orders { get; set; }

        public override string ToString()
        {
            return StoreLocation;
        }
    }
}