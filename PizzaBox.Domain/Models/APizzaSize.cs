using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class APizzaSize
    {
        public APizzaSize()
        {
            Pizzas = new HashSet<APizza>();
        }

        public int PizzaSizeId { get; set; }
        public string PizzaSizeName { get; set; }
        public int PizzaSizeInches { get; set; }
        public decimal PizzaSizePrice { get; set; }

        public virtual ICollection<APizza> Pizzas { get; set; }
    }
}
