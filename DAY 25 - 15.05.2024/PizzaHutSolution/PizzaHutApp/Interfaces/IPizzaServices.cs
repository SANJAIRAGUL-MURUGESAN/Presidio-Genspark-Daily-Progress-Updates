using PizzaHutApp.Models.DTOs;
using PizzaHutApp.Models;

namespace PizzaHutApp.Interfaces
{
    public interface IPizzaServices
    {
        public Task<Pizza> AddPizza(Pizza pizza);
        public Task<IEnumerable<Pizza>> GetAllAvailablePizzas();
    }
}
