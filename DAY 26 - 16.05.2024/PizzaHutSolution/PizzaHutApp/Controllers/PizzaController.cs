using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutApp.Interfaces;
using PizzaHutApp.Models.DTOs;
using PizzaHutApp.Models;
using PizzaHutApp.Services;
using PizzaHutApp.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace PizzaHutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaService;
        public PizzaController(IPizzaServices pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpPost("AddPizza")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Pizza>> AddPizza(AddPizzaDTO pizzaDTO)
        {
            try
            {
                var result = await _pizzaService.AddPizza(pizzaDTO);
                return result;
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetAllPizzas")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<IList<Pizza>> GetAllPizzas()
        {
                var result = await _pizzaService.GetAllAvailablePizzas();
                return result.ToList();
        }
    }
}
