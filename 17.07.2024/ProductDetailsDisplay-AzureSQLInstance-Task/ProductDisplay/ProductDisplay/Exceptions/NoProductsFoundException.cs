namespace ProductDetailsDisplay.Exceptions
{
    public class NoProductsFoundException : Exception
    {
        string msg;
        public NoProductsFoundException()
        {
            msg = "No Products Found!";
        }
        public override string Message => msg;
    }
}
