using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.RequestExceptions
{
    public class NoRequestSolutionFoundException : Exception
    {
        string message;
        public NoRequestSolutionFoundException()
        {
            message = "No Certain Request Solution Found!";
        }
        public override string Message => message;
    }
}
