namespace PizzaHutApp.Exceptions
{
    public class NoSuchPizzaFoundException : Exception
    {
        string message;
        public NoSuchPizzaFoundException()
        {
            message = "No Such Pizza Found!";
        }
        public override string Message => message;
    }
}
