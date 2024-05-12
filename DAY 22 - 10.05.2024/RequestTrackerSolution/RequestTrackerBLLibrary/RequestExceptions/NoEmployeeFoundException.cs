using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.RequestExceptions
{
    public class NoEmployeeFoundException : Exception
    {
        string message;
        public NoEmployeeFoundException()
        {
            message = "No Certain Employee Found!";
        }
        public override string Message => message;
    }
}
