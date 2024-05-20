namespace PizzaHutApp.Exceptions
{
    public class NoPizzasFoundException : Exception
    {
        string message;
        public NoPizzasFoundException()
        {
            message = "No Pizzas Found!";
        }
        public override string Message => message;

    }
}
