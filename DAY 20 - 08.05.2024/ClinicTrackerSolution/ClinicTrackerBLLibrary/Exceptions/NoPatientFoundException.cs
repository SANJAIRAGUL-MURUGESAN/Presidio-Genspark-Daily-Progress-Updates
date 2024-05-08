using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary.Exceptions
{
    public class NoPatientFoundException : Exception
    {
        string message;
        public NoPatientFoundException()
        {
            message = "No Patient Found!";
        }
        public override string Message => message;
    }
}
