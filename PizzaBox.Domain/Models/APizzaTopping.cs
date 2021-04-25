namespace PizzaBox.Domain.Models
{
  public partial class APizzaTopping
  {
    public int PizzaToppingId { get; set; }
    public int PizzaId { get; set; }
    public byte ToppingId { get; set; }
    public byte ToppingCount { get; set; }

    //public virtual APizza Pizza { get; set; }
    //public virtual ATopping Topping { get; set; }
  }
}