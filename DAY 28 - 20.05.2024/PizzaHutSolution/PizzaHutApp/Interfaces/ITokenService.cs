using PizzaHutApp.Models;

namespace PizzaHutApp.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
