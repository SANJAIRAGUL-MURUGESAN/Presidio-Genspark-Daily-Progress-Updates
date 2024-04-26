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
        public  async Task<Cart> AddCart(Cart cart)
        {
            var result = await _CartRepository.Add(cart);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<Cart> DeleteCart(int id)
        {
            var result = await _CartRepository.Delete(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoCartWithGivenIdException();
        }

        public async Task<Cart> GetCart(int id)
        {
            var result = await _CartRepository.GetByKey(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoCartWithGivenIdException();
        }

        public async Task<Cart> AddCartItem(CartItem item)
        {
            var result = await _CartRepository.GetByKey(item.CartId);
            List<CartItem> List = result.CartItems;
            if (List == null)
            {
                result.CartItems = new List<CartItem> { item };
                //result.CartItems = new List<CartItem>();
                //result.CartItems.Add(item);
            }
            else if(List != null)
            {
                int ActualCount = 0;
                for(int i = 0; i < List.Count; i++)
                {
                    int Count = List[i].Quantity;
                    ActualCount = ActualCount + Count;
                }
                if(ActualCount < 5 )
                {
                    int flag = 0;
                    for (int i = 0; i < List.Count; i++)
                    {
                        if (result.CartItems[i].ProductId == item.ProductId)
                        {
                            if ((ActualCount + item.Quantity) < 5)
                            {
                                result.CartItems[i].Quantity = result.CartItems[i].Quantity + item.Quantity;
                                flag = 1;
                                break;
                            }
                        }
                        else
                        {
                            throw new CartItemEntryFullException();
                        }
                    }
                    if(flag == 0)
                    {
                        if ((ActualCount + item.Quantity) < 5)
                        {
                            result.CartItems.Add(item);
                        }
                        else
                        {
                            throw new CartItemEntryFullException();
                        }

                    }
                }
            }
            var result2 = await _CartRepository.Update(result);
            return result2;
        }

        public async Task<Cart> DeleteCartItem(CartItem item, int productId)
        {
            Cart cart = await _CartRepository.GetByKey(item.CartId);
            CartItem ItemToRemove = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (ItemToRemove != null)
            {
                cart.CartItems.Remove(ItemToRemove);
            }
            return await _CartRepository.Update(cart);
        }

        public async Task<double> CustomerPurchase(int id) // CartId
        {
            var result = await _CartRepository.GetByKey(id);
            if (result != null)
            {
                List<CartItem> List = result.CartItems;
                if (List == null)
                {
                    return 0;
                }
                double price = 0;
                for (int i = 0; i < List.Count; i++)
                {
                    price = price + List[i].Price;
                    price = price * List[i].Quantity;
                }
                if (price < 100)
                {
                    return price + 100;
                }
                else if (List.Count == 3 && price >= 1500)
                {
                    return price - (price * 5 % 100);
                }
                else
                {
                    return price;
                }
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
