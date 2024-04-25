using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.ProductExceptions
{
    public class NoProductWithGivenIDException : Exception
    {
        string message;
        public NoProductWithGivenIDException()
        {
            message = "Product with the given Id is not present";
        }
        public override string Message => message;
    }
}
