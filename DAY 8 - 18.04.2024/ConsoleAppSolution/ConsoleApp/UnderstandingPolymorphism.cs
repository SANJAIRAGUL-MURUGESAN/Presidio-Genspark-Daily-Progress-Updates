using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FullTimeEmployee : Employee
    {
        public override void PrintEmployeeDetails()
        {
            Console.WriteLine($"FirstName: {FullName} LastName: {LastName} Type: FullTime");
        }
    }
    public class PartTimeEmployee : Employee
    {
        public override void PrintEmployeeDetails()
        {
            Console.WriteLine($"FirstName: {FullName} LastName: {LastName} Type: PartTime");
        }
    }
    public class Employee
    {
        public string FullName { set; get; }
        public string LastName { get; set; }

        public Employee()
        {
            FullName = "Sanjai";
            LastName = "Ragul";
        }

        public Employee(string fullname,string lastname)
        {
            FullName = fullname;
            LastName = lastname;
        }

        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine($"FirstName: {FullName} LastName: {LastName} Type: Temporary");
        }
    }
}
