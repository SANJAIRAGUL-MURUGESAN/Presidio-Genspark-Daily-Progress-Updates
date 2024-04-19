using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.EmployeeExceptions
{
    public class NoEmployeeFoundException : Exception
    {
        string msg;
        public NoEmployeeFoundException()
        {
            msg = "No Employee Found!";
        }
        public override string Message => msg;
    }
}
