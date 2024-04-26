using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.ProductExceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBL
{
    public class ProductBL : IProductService
    {
        readonly IRepository<int, Product> _productRepository;
        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [ExcludeFromCodeCoverage]
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _productRepository.Add(product);
            if (result != null)
            {
                return result;
            }
            throw new NoProductWithGivenIDException();
        }

        public async Task<Product> deleteProduct(int id)
        {
            var result = await _productRepository.Delete(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            List<Product> result = (List<Product>)await _productRepository.GetAll();
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }

        public async Task<Product> GetProduct(int id)
        {
            var result = await _productRepository.GetByKey(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }

        public async Task<Product> UpdateProductName(int id,string Newname)
        {
            var result = await _productRepository.GetByKey(id);
            result.Name = Newname;
            var result2 = await _productRepository.Update(result);
            return result2;
            //if (result != null)
            //{
            //    result.Name = Newname;
            //    var result2 = _productRepository.Update(result);
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }
    }
}
