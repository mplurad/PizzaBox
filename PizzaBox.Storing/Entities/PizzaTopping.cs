using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("PizzaTopping")]
    [Index(nameof(PizzaId), nameof(ToppingId), Name = "PizzaID_ToppingID_Unique", IsUnique = true)]
    public partial class PizzaTopping
    {
        [Key]
        [Column("PizzaToppingID")]
        public int PizzaToppingId { get; set; }
        [Column("PizzaID")]
        public int PizzaId { get; set; }
        [Column("ToppingID")]
        public int ToppingId { get; set; }
        public int ToppingCount { get; set; }

        [ForeignKey(nameof(PizzaId))]
        [InverseProperty("PizzaToppings")]
        public virtual Pizza Pizza { get; set; }
        [ForeignKey(nameof(ToppingId))]
        [InverseProperty("PizzaToppings")]
        public virtual Topping Topping { get; set; }
    }
}
