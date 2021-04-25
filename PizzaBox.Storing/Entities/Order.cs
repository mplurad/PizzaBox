using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            Pizzas = new HashSet<Pizza>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("StoreID")]
        public byte StoreId { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Orders")]
        public virtual Store Store { get; set; }
        [InverseProperty(nameof(Pizza.Order))]
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
