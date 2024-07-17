using Microsoft.EntityFrameworkCore;
using ProductDetailsDisplay.Contexts;
using ProductDetailsDisplay.Exceptions;
using ProductDetailsDisplay.Interfaces;
using ProductDetailsDisplay.Models;

namespace ProductDetailsDisplay.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ProductDetailsContext _context;
        public ProductRepository(ProductDetailsContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Product> Delete(int key)
        {
            var admin = await GetbyKey(key);
            if (admin != null)
            {
                _context.Remove(admin);
                await _context.SaveChangesAsync(true);
                return admin;
            }
            throw new NoSuchProductFoundException();
        }
        public async Task<Product> GetbyKey(int key)
        {
            var product = await _context.Products.FirstOrDefaultAsync(t => t.Id == key);
            if (product != null)
            {
                return product;
            }
            throw new NoSuchProductFoundException();
        }
        public async Task<IEnumerable<Product>> Get()
        {
            var product = await _context.Products.ToListAsync();
            if (product != null)
            {
                return product;
            }
            throw new NoProductsFoundException();
        }
        public async Task<Product> Update(Product item)
        {
            var product = await GetbyKey(item.Id);
            if (product != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return product;
            }
            throw new NoSuchProductFoundException();
        }
    }
}
