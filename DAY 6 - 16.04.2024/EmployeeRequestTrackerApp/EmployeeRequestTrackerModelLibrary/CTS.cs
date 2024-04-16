using System.Globalization;
using System.Runtime.ConstrainedExecution;
using EmployeeRequestTrackerApp;
namespace EmployeeRequestTrackerModelLibrary
{
    public class CTS : IGovtRlues
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeDepartment { get; set; }
        public string EmployeeDesignation { get; set; }
        public string CompanyName { get; set; }
        public double EmployeeBasicSalary { get; set; }
        public float ServiceCompleted { get; set; }

        CTS[] CtsEmployees;
        public CTS()
        {
            CtsEmployees = new CTS[2];
        }

        public CTS GetInfofromConsole(int i)
        {
            CTS employee = new CTS();
            employee.EmployeeId = 101 + i;
            employee.CompanyName = "CTS";
            Console.WriteLine("Please Enter the Employee Name : ");
            employee.EmployeeName = Console.ReadLine();
            Console.WriteLine("Please Enter the Employee Department : ");
            employee.EmployeeDepartment = Console.ReadLine();
            Console.WriteLine("Please Enter the Employee Designation : ");
            employee.EmployeeDesignation = Console.ReadLine();
            Console.WriteLine("Please Enter the Employee Basic Salary: ");
            employee.EmployeeBasicSalary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter the Employee Service Completed: ");
            employee.ServiceCompleted = float.Parse(Console.ReadLine());
            return employee;
        }

        public void GetEmployerDetails()
        {
            if (CtsEmployees[CtsEmployees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < CtsEmployees.Length; i++)
            {
                if (CtsEmployees[i] == null)
                {
                    CtsEmployees[i] = GetInfofromConsole(i);
                }
            }
        }

        public CTS(int Employeeid,string Employeename,string Employeedepartment,string Employeedesignation, string Companyname,double Employeesalary, float Servicecompleted)
        {
            EmployeeId = Employeeid;
            EmployeeName = Employeename;
            EmployeeDepartment = Employeedepartment;
            EmployeeDesignation = Employeedesignation;
            CompanyName = Companyname;
            EmployeeBasicSalary = Employeesalary;
            ServiceCompleted = Servicecompleted;
        }

       

        public double EmployeePF(double BasicSalary)
        {
            double EmployeePF = (BasicSalary * 12) / 100;
            double EmployerPF = (BasicSalary * 8.33) / 100;
            Console.WriteLine("Employee Contribution : " + (EmployerPF + EmployeePF));
            return (EmployerPF + EmployeePF);
        }



        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted < 5)
            {
                Console.WriteLine("Your Gratuity Amount is : " + 0);
                return 0;
            }
            else if (serviceCompleted > 5 && serviceCompleted <= 10)
            {
                Console.WriteLine($"Your Gratuity Amount is : {basicSalary}");
                return basicSalary;
            }
            else if (serviceCompleted > 10 && serviceCompleted <= 20)
            {
                Console.WriteLine($"Your Gratuity Amount is : { basicSalary * 2}");
                return serviceCompleted * 2;
            }
            Console.WriteLine($"Your Gratuity Amount is : {basicSalary * 3}");
            return serviceCompleted * 3;
        }

        public string LeaveDetails()
        {
            String Leavedetails = "1 day of Casual Leave per month" + " " + "12 days of Sick Leave per year" + " " + "10 days of Privilege Leave per year";
            Console.WriteLine("Leave Details : 1 day of Casual Leave per month, 12 days of Sick Leave per year, 10 days of Privilege Leave per year");
            return Leavedetails;
        }

        public void DetailsShowcase()
        {
            Result result = new Result();
            for(int i = 0; i < CtsEmployees.Length; i++)
            {
                result.ResultDetails(CtsEmployees[i], CtsEmployees[i].ServiceCompleted, CtsEmployees[i].EmployeeBasicSalary);
            }
        }
    }
}
