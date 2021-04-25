using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("Topping")]
    [Index(nameof(ToppingName), Name = "UQ__Topping__612DF4CD21883F5D", IsUnique = true)]
    public partial class Topping
    {
        public Topping()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }

        [Key]
        [Column("ToppingID")]
        public byte ToppingId { get; set; }
        [Required]
        [StringLength(50)]
        public string ToppingName { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal ToppingPrice { get; set; }

        [InverseProperty(nameof(PizzaTopping.Topping))]
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
