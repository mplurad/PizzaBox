using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("Pizza")]
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }

        [Key]
        [Column("PizzaID")]
        public int PizzaId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CrustID")]
        public byte CrustId { get; set; }
        [Column("PizzaSizeID")]
        public byte PizzaSizeId { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal PizzaPrice { get; set; }

        [ForeignKey(nameof(CrustId))]
        [InverseProperty("Pizzas")]
        public virtual Crust Crust { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Pizzas")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(PizzaSizeId))]
        [InverseProperty("Pizzas")]
        public virtual PizzaSize PizzaSize { get; set; }
        [InverseProperty(nameof(PizzaTopping.Pizza))]
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
