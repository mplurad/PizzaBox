using System;
namespace PizzaBox.Client.Models
{
    public class PizzaSize
    {
        public PizzaSize()
        {
        }

        public int PizzaSizeId { get; set; }
        public string PizzaSizeName { get; set; }
        public int PizzaSizeInches { get; set; }
        public decimal PizzaSizePrice { get; set; }
    }
}
