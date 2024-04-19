using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.DepartmentExceptions
{
    public class NoDepartmentFoundException : Exception
    {
        string msg;
        public NoDepartmentFoundException()
        {
            msg = "No Department Found!";
        }
        public override string Message => msg;
    }
}
