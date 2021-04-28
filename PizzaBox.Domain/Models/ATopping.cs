using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class ATopping
    {
        public ATopping()
        {
            //PizzaToppings = new HashSet<APizzaTopping>();
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }

        //public virtual ICollection<APizzaTopping> PizzaToppings { get; set; }
    }
}
