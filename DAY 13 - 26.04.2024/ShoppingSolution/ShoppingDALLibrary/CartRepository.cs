using ShoppingModelLibrary.CustomerExceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary.CartException;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        
        public override async Task<Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }

        public override async Task<Cart> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCartWithGivenIdException();
        }

        public override async Task<Cart> Update(Cart item)
        {
            int index = items.FindIndex((element) => element.Id == item.Id);
            if (index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
