using PizzaHutApp.Exceptions;
using PizzaHutApp.Interfaces;
using PizzaHutApp.Models;

namespace PizzaHutApp.Services
{
    public class PizzaService : IPizzaServices
    {
        private readonly IRepository<int, Pizza> _repository;
        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }
        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            var result = await _repository.Add(pizza);
            if (result != null)
            {
                return result;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pizza>> GetAllAvailablePizzas()
        {
            List<Pizza> result = (List<Pizza>)await _repository.Get();
            List<Pizza> List = new List<Pizza>();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].IsAvailable == true)
                {
                    List.Add(result[i]);
                }
            }
            if(List.Count > 0)
            {
                //return result.ToList();
                return List;
            }
            throw new NoPizzasFoundException();
        }
    }
}
