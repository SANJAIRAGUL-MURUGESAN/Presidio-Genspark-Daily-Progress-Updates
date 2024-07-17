using ProductDetailsDisplay.Exceptions;
using ProductDetailsDisplay.Interfaces;
using ProductDetailsDisplay.Models;
using ProductDisplay.Models.ProductDTOs;

namespace ProductDetailsDisplay.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<int, Product> _ProductRepository;

        public ProductServices(IRepository<int, Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public async Task<IList<Product>> GetAllProducts()
        {
            try
            {
                var ProductDetails = await _ProductRepository.Get();
                if (ProductDetails != null)
                {
                    return ProductDetails.ToList();
                }
                throw new NoProductsFoundException();
            }
            catch (NoProductsFoundException)
            {
                throw new NoProductsFoundException();
            }
        }

        public Product MapAddProductDTOtoProduct(AddproductDTO addproductDTO)
        {
            Product product = new Product();
            product.ProductName = addproductDTO.ProductName;
            product.ProductPrice = addproductDTO.ProductPrice;
            product.PoductImage = addproductDTO.ProductImage;
            return product;
        }

        public AddProductReturnDTO MapProductTOAddProductReturnDTO(Product product)
        {
            AddProductReturnDTO addProductReturnDTO = new AddProductReturnDTO();
            addProductReturnDTO.ProductName = product.ProductName;
            addProductReturnDTO.ProductPrice = product.ProductPrice;
            addProductReturnDTO.ProductImage = product.PoductImage;
            return addProductReturnDTO;
        }

        public async Task<AddProductReturnDTO> AddProducts(AddproductDTO addproductDTO)
        {
            try
            {
                var Product = MapAddProductDTOtoProduct(addproductDTO);
                var ProductDetails = await _ProductRepository.Add(Product);
                return MapProductTOAddProductReturnDTO(ProductDetails);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }

}
