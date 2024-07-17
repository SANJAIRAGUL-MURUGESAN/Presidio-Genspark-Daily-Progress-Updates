using Microsoft.AspNetCore.Mvc;
using ProductDetailsDisplay.Exceptions;
using ProductDetailsDisplay.Interfaces;
using ProductDetailsDisplay.Models;
using ProductDisplay.Models.ProductDTOs;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace ProductDetailsDisplay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductService;
        public ProductController(IProductServices productService)
        {
            _ProductService = productService;
        }

        [Route("ProductDetails")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Product>>> GetProducts()
        {
            try
            {
                var ProductDetails = await _ProductService.GetAllProducts();
                return Ok(ProductDetails);
            }
            catch (NoProductsFoundException npfe)
            {
                return NotFound(new ErrorModel(404, npfe.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Route("AddProductDetails")]
        [HttpPost]
        [ProducesResponseType(typeof(AddProductReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<AddProductReturnDTO>> AddProduct([FromBody] AddproductDTO addproductDTO)
        {
            try
            {
                var AddProductDetails = await _ProductService.AddProducts(addproductDTO);
                return Ok(AddProductDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }
    }
}
