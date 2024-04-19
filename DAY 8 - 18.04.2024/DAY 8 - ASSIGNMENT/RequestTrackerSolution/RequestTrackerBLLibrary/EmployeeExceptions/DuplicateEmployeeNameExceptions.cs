using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.EmployeeExceptions
{
    public class DuplicateEmployeeNameExceptions : Exception
    {
        string msg;
        public DuplicateEmployeeNameExceptions()
        {
            msg = "Employee Name Already Exits!";
        }
        public override string Message => msg;
    }
}
