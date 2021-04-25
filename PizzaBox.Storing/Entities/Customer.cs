using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("Customer")]
    [Index(nameof(Username), Name = "UQ__Customer__536C85E458A06FC3", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }
        [StringLength(10)]
        public string CustomerPhone { get; set; }
        [StringLength(50)]
        public string CustomerAddress { get; set; }
        [StringLength(16)]
        public string CustomerCardNumber { get; set; }
        [StringLength(4)]
        public string CustomerCardDate { get; set; }
        [Column("CustomerCardCVV")]
        [StringLength(3)]
        public string CustomerCardCvv { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
