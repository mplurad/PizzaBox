using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class Pizza
    {
        public Pizza()
        {
            HashSet<PizzaTopping> PizzaToppings = new HashSet<PizzaTopping>();
        }

        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int CrustId { get; set; }
        public int PizzaSizeId { get; set; }
        public decimal PizzaPrice { get; set; }
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
