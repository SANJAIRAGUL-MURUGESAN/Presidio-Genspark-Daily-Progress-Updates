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
        Cart AddCart(Cart cart);
        Cart GetCart(int id);
        Cart DeleteCart(int id);
        Cart AddCartItem(CartItem item);
        double CustomerPurchase(Cart item);
    }
}
