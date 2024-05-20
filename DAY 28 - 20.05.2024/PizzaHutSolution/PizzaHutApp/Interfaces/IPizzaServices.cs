using PizzaHutApp.Models.DTOs;
using PizzaHutApp.Models;

namespace PizzaHutApp.Interfaces
{
    public interface IPizzaServices
    {
        public Task<Pizza> AddPizza(AddPizzaDTO pizzaDTO);
        public Task<IEnumerable<Pizza>> GetAllAvailablePizzas();
    }
}
