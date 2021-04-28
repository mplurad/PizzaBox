using System;
namespace PizzaBox.Client.Models
{
    public class Topping
    {
        public Topping()
        {
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }
    }
}
