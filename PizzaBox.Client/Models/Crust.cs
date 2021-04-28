using System;
namespace PizzaBox.Client.Models
{
    public class Crust
    {
        public Crust()
        {
        }

        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public decimal CrustPrice { get; set; }
    }
}
