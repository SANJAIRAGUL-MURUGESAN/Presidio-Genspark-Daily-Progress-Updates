using Microsoft.EntityFrameworkCore;
using ProductDetailsDisplay.Models;

namespace ProductDetailsDisplay.Contexts
{
    public class ProductDetailsContext : DbContext
    {
        public ProductDetailsContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
