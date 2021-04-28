using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("Crust")]
    [Index(nameof(CrustName), Name = "UQ__Crust__C2369FD2C79F5523", IsUnique = true)]
    public partial class Crust
    {
        public Crust()
        {
            Pizzas = new HashSet<Pizza>();
        }

        [Key]
        [Column("CrustID")]
        public int CrustId { get; set; }
        [StringLength(50)]
        public string CrustName { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal CrustPrice { get; set; }

        [InverseProperty(nameof(Pizza.Crust))]
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
