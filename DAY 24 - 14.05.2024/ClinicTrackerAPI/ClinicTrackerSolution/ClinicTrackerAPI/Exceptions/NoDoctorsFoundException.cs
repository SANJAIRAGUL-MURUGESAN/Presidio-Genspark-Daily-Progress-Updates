namespace ClinicTrackerAPI.Exceptions
{
    public class NoDoctorsFoundException : Exception
    {
        string message;
        public NoDoctorsFoundException()
        {
            message = "No Doctors Found!";
        }
        public override string Message => message;
    }
}
