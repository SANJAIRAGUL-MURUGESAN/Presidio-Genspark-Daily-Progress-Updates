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
        public Product AddProduct(Product product)
        {
            var result = _productRepository.Add(product);
            if (result != null)
            {
                return result;
            }
            throw new NoProductWithGivenIDException();
        }

        public Product deleteProduct(int id)
        {
            var result = _productRepository.Delete(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }

        public List<Product> GetAllProduct()
        {
            List<Product> result = (List<Product>)_productRepository.GetAll();
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }

        public Product GetProduct(int id)
        {
            var result = _productRepository.GetByKey(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoProductWithGivenIDException();
        }

        public Product UpdateProductName(int id,string Newname)
        {
            var result = _productRepository.GetByKey(id);
            result.Name = Newname;
            var result2 = _productRepository.Update(result);
            return result;
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
