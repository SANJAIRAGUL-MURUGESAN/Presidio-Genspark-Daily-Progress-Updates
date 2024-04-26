using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetAllProduct();
        Task<Product> UpdateProductName(int id,string Newname);
        Task<Product> deleteProduct(int id);
    }
}
