namespace PizzaHutApp.Exceptions
{
    public class NoSuchCustomerFoundException : Exception
    {
        string message;
        public NoSuchCustomerFoundException()
        {
            message = "No Such Customer Found!";
        }
        public override string Message => message;
    }
}
