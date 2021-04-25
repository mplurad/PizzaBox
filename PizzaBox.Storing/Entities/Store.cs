using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("Store")]
    [Index(nameof(StoreLocation), Name = "UQ__Store__AB9F35EF41AD8650", IsUnique = true)]
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("StoreID")]
        public byte StoreId { get; set; }
        [Required]
        [StringLength(100)]
        public string StoreLocation { get; set; }

        [InverseProperty(nameof(Order.Store))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
