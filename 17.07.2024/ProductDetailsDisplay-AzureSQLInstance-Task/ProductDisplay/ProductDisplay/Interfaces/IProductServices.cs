using ProductDetailsDisplay.Models;
using ProductDisplay.Models.ProductDTOs;

namespace ProductDetailsDisplay.Interfaces
{
    public interface IProductServices
    {
        public Task<IList<Product>> GetAllProducts();
        public Task<AddProductReturnDTO> AddProducts(AddproductDTO addproductDTO);
    }
}
