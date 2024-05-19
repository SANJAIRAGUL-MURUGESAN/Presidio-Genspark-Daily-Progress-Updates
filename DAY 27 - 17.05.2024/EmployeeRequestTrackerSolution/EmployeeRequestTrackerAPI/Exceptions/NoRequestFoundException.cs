namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoRequestFoundException :Exception
    {
        string msg;
        public NoRequestFoundException()
        {
            msg = "No Requests Found";
        }
        public override string Message => msg;
    }
}
