using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public partial class APizza
  {
    public APizza()
    {
      PizzaToppings = new HashSet<APizzaTopping>();
    }

    public int PizzaId { get; set; }
    public int OrderId { get; set; }
    public byte CrustId { get; set; }
    public byte PizzaSizeId { get; set; }
    public decimal PizzaPrice { get; set; }

    //public virtual ACrust Crust { get; set; }
    //public virtual AOrder Order { get; set; }
    //public virtual APizzaSize PizzaSize { get; set; }
    public virtual ICollection<APizzaTopping> PizzaToppings { get; set; }
  }
}
