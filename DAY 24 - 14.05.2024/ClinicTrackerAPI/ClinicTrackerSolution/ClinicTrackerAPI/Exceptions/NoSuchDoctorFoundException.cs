namespace ClinicTrackerAPI.Exceptions
{
    public class NoSuchDoctorFoundException : Exception
    {
        string message;
        public NoSuchDoctorFoundException()
        {
            message = "No Such Doctor Found!";
        }
        public override string Message => message;
    }
}
