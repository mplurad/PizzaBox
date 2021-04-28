using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class ACrust
    {
        public ACrust()
        {
            Pizzas = new HashSet<APizza>();
        }

        /*public static ACrust SelectCrust(IRepository r)
        {
          ACrust crust = new ACrust();
          return r.GetCrust(1);
        }*/

        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public decimal CrustPrice { get; set; }

        public virtual ICollection<APizza> Pizzas { get; set; }
    }
}
