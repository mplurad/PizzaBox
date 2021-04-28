using System;
namespace PizzaBox.Client.Models
{
    public class Store
    {
        public Store()
        {
        }

        public byte StoreId { get; set; }
        public string StoreLocation { get; set; }

        public override string ToString()
        {
            return StoreLocation;
        }
    }
}