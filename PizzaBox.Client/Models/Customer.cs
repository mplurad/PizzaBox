using System;
namespace PizzaBox.Client.Models
{
    public class Customer
    {
        public Customer()
        {
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
    }
}
