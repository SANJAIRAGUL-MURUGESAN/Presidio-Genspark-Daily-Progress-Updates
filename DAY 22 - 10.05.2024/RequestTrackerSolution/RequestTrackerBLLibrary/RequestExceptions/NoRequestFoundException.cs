using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.RequestExceptions
{
    public class NoRequestFoundException : Exception
    {
        string message;
        public NoRequestFoundException()
        {
            message = "No Certain Request Found!";
        }
        public override string Message => message;
    }
}
