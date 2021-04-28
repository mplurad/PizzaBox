using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public partial class ACustomer
  {
    public ACustomer()
    {
      //Orders = new HashSet<AOrder>();
    }

    public override string ToString()
    {
      return $"{CustomerFirstName} {CustomerLastName}";
    }

    public int CustomerId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerCardNumber { get; set; }
    public string CustomerCardDate { get; set; }
    public string CustomerCardCvv { get; set; }

    //public virtual ICollection<AOrder> Orders { get; set; }
  }
}