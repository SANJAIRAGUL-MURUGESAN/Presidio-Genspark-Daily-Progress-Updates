using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerModelLibrary
{
    public interface IGovtRlues
    {
        public double EmployeePF(double basicSalary);
        public string LeaveDetails();
        public double gratuityAmount(float serviceCompleted, double basicSalary);
    }
}
