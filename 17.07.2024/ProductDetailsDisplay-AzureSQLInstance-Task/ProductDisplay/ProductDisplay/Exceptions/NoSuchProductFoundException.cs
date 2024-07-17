namespace ProductDetailsDisplay.Exceptions
{
    public class NoSuchProductFoundException : Exception
    {
        string msg;
        public NoSuchProductFoundException()
        {
            msg = "No Such Products Found!";
        }
        public override string Message => msg;
    }
}
