using PizzaHutApp.Models;
using PizzaHutApp.Models.DTOs;

namespace PizzaHutApp.Interfaces
{
    public interface IUserServices
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerUserDTO customerDTO);
    }
}
