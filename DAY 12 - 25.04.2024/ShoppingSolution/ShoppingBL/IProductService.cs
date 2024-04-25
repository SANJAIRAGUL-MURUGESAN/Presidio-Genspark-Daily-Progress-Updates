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
        Product AddProduct(Product product);
        Product GetProduct(int id);
        List<Product> GetAllProduct();
        Product UpdateProductName(int id,string Newname);
        Product deleteProduct(int id);
    }
}
