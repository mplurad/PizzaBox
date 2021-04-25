using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    public partial class HeroesDbmilesContext : DbContext
    {
        public HeroesDbmilesContext()
        {
        }

        public HeroesDbmilesContext(DbContextOptions<HeroesDbmilesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crusts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaSize> PizzaSizes { get; set; }
        public virtual DbSet<PizzaTopping> PizzaToppings { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["HeroesDb-miles"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.Property(e => e.CrustId).ValueGeneratedOnAdd();

                entity.Property(e => e.CrustName).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerAddress).IsUnicode(false);

                entity.Property(e => e.CustomerCardCvv)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerCardDate)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerCardNumber)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerFirstName).IsUnicode(false);

                entity.Property(e => e.CustomerLastName).IsUnicode(false);

                entity.Property(e => e.CustomerPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CustomerI__451F3D2B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__StoreID__46136164");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__CrustID__4F9CCB9E");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__OrderID__4EA8A765");

                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.PizzaSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__PizzaSize__5090EFD7");
            });

            modelBuilder.Entity<PizzaSize>(entity =>
            {
                entity.Property(e => e.PizzaSizeId).ValueGeneratedOnAdd();

                entity.Property(e => e.PizzaSizeName).IsUnicode(false);
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__Pizza__573DED66");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__Toppi__5832119F");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.StoreLocation).IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.ToppingId).ValueGeneratedOnAdd();

                entity.Property(e => e.ToppingName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
