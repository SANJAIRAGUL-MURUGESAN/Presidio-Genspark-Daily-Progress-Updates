using Microsoft.EntityFrameworkCore;
using PizzaHutApp.Models;

namespace PizzaHutApp.Contexts
{
    public class PizzaHutContext : DbContext
    {
        public PizzaHutContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Email = "ramu@gmail,com", Address = "Tamilnadu", Role = "User" },
                new Customer() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Email = "somu@gmail.com", Address =  "Tamilnadu", Role = "Admin"}
                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { PizzaId = 110, Name = "Pizza1", DiameterInches = 5, IsVeg = false, Price = 300, IsAvailable = true },
                new Pizza() { PizzaId = 120, Name = "Pizza2", DiameterInches = 5, IsVeg = false, Price = 400, IsAvailable = true }
                );
        }

    }
}
