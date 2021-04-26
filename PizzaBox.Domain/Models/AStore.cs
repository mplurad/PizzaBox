using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public partial class AStore
  {
    public AStore()
    {
      Orders = new HashSet<AOrder>();
    }

    public static void DisplayStores(List<AStore> stores)
    {
      var index = 0;
      foreach (AStore store in stores)
      {
        Console.WriteLine($"{++index} - {store}");
      }
    }

    public static AStore SelectStore(List<AStore> stores)
    {
      Console.Write("Select a PizzaBox store location: ");
      try
      {
        var input = int.Parse(Console.ReadLine());
        return stores[input - 1];
      }
      catch (Exception)
      {
        return SelectStore(stores);
      }
    }

    public byte StoreId { get; set; }
    public string StoreLocation { get; set; }

    public virtual ICollection<AOrder> Orders { get; set; }

    public override string ToString()
    {
      return StoreLocation;
    }
  }
}