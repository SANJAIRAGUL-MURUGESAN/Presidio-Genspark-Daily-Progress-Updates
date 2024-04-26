using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.CartException
{
    public class CartItemEntryFullException : Exception
    {
        string message;
        public CartItemEntryFullException()
        {
            message = "Your Cart has Already 5 Items!";
        }
        public override string Message => message;
    }
}
