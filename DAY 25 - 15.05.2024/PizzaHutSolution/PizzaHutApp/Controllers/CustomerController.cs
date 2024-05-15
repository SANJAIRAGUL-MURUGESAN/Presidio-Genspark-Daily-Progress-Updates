using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutApp.Interfaces;
using PizzaHutApp.Models.DTOs;
using PizzaHutApp.Models;
using PizzaHutApp.Services;

namespace PizzaHutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerService;
        public CustomerController(ICustomerServices employeeService)
        {
            _customerService = employeeService;
        }

        [HttpGet("GetAllCustomers")]
        [ProducesResponseType(typeof(IList<Customer>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<IList<Customer>> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomers();
            return result.ToList();
        }
    }
}
