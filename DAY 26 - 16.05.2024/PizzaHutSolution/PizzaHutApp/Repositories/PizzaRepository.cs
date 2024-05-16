using Microsoft.EntityFrameworkCore;
using PizzaHutApp.Contexts;
using PizzaHutApp.Exceptions;
using PizzaHutApp.Interfaces;
using PizzaHutApp.Models;
using PizzaHutApp.Models.DTOs;

namespace PizzaHutApp.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaHutContext _context;
        public PizzaRepository(PizzaHutContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchPizzaFoundException();
        }
        public async Task<Pizza> Get(int key)
        {
            return (await _context.Pizzas.SingleOrDefaultAsync(u => u.PizzaId == key)) ?? throw new NoSuchPizzaFoundException();
        }
        public async Task<IEnumerable<Pizza>> Get()
        {
            return (await _context.Pizzas.ToListAsync());
        }
        public async Task<Pizza> Update(Pizza item)
        {
            var user = await Get(item.PizzaId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchPizzaFoundException();
        }
    }
}
