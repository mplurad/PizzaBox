using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("PizzaSize")]
    [Index(nameof(PizzaSizeName), Name = "UQ__PizzaSiz__F84F0608DD306BD2", IsUnique = true)]
    public partial class PizzaSize
    {
        public PizzaSize()
        {
            Pizzas = new HashSet<Pizza>();
        }

        [Key]
        [Column("PizzaSizeID")]
        public int PizzaSizeId { get; set; }
        [Required]
        [StringLength(50)]
        public string PizzaSizeName { get; set; }
        public int PizzaSizeInches { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal PizzaSizePrice { get; set; }

        [InverseProperty(nameof(Pizza.PizzaSize))]
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
