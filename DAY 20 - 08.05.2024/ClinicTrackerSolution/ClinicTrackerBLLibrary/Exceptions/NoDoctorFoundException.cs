using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary.Exceptions
{
    public class NoDoctorFoundException : Exception
    {
        string message;
        public NoDoctorFoundException()
        {
            message = "No Doctor Found!";
        }
        public override string Message => message;

    }
}
