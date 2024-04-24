using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public class CartBL : ICartService
    {
        readonly IRepository<int, Cart> _CartRepository;
        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _CartRepository = cartRepository;
        }

        [ExcludeFromCodeCoverage]
        public Cart AddCart(Cart cart)
        {
            var result = _CartRepository.Add(cart);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart DeleteCart(int id)
        {
            var result = _CartRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart GetCart(int id)
        {
            var result = _CartRepository.GetByKey(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart AddCartItem(CartItem item)
        {
            var result = _CartRepository.GetByKey(item.CartId);
            List<CartItem> List = result.CartItems;
            if (List.Count < 5)
            {
                result.CartItems.Add(item);
                var result2 =  _CartRepository.Update(result);
                return result2;
            }
            throw new NoCartWithGivenIdException();
        }

        public double CustomerPurchase(Cart cart)
        {
            var result = _CartRepository.GetByKey(cart.Id);
            List<CartItem> List = result.CartItems;
            double price = 0;
            for(int i = 0; i < List.Count; i++)
            {
                price = price + List[i].Price;
            }
            if(price < 100)
            {
                return price + 100;
            }
            else if(List.Count == 3 && price > 1500)
            {
                return price - (price * 5 % 100);
            }
            else
            {
                return price;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
