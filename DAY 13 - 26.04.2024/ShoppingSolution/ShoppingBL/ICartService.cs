using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public interface ICartService
    {
        Task<Cart> AddCart(Cart cart);
        Task<Cart> GetCart(int id);
        Task<Cart> DeleteCart(int id);
        Task<Cart> AddCartItem(CartItem item);
        Task<double> CustomerPurchase(int id);
    }
}
