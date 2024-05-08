using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary.Exceptions
{
    public class NoAppointmentFoundException : Exception
    {
        string message;
        public NoAppointmentFoundException()
        {
            message = "No Appointment Found!";
        }
        public override string Message => message;
    }
}
