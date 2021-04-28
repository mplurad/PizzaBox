using System;
namespace PizzaBox.Client.Models
{
    public class PizzaTopping
    {
        public PizzaTopping()
        {
        }

        public int PizzaToppingId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public int ToppingCount { get; set; }
    }
}
