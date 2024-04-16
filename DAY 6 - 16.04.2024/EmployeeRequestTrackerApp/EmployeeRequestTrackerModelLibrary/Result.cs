using EmployeeRequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerApp
{
    public class Result
    {
        public void ResultDetails(IGovtRlues data,float ServiceC, double Salary)
        {
            data.gratuityAmount(ServiceC,Salary);
            data.LeaveDetails();
            data.EmployeePF(Salary);
        }
    }
}
