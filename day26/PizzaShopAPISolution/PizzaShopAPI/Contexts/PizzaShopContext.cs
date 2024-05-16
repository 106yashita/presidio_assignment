using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PizzaShopAPI.Contexts
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321",Role="user"},
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655",Role = "user" }
                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { pizzaId = 101, name = "paneer pizza", description = "paneer", availableStock = 3 },
                new Pizza() { pizzaId = 102, name = "corn pizza", description = "corn", availableStock = 0 }
                );
        }
    }
}
