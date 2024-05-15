using PizzaHutApp.Models;
using PizzaHutApp.Models.DTOs;

namespace PizzaHutApp.Interfaces
{
    public interface IUserServices
    {
        public Task<Customer> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerUserDTO customerDTO);
    }
}
