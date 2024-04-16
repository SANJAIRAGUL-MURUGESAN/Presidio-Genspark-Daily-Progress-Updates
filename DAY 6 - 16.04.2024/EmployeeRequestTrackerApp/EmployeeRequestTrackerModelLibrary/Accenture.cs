using System.Globalization;
using System.Runtime.ConstrainedExecution;
using EmployeeRequestTrackerApp;
namespace EmployeeRequestTrackerModelLibrary
{
    public class Accenture : IGovtRlues
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeDepartment { get; set; }
        public string EmployeeDesignation { get; set; }
        public string CompanyName { get; set; }
        public double EmployeeBasicSalary { get; set; }
        public float ServiceCompleted { get; set; }

        Accenture[] AccEmployees;
        public Accenture()
        {
            AccEmployees = new Accenture[2];
        }

        public Accenture GetInfofromConsole(int i)
        {
            Accenture employee = new Accenture();
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
            if (AccEmployees[AccEmployees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < AccEmployees.Length; i++)
            {
                if (AccEmployees[i] == null)
                {
                    AccEmployees[i] = GetInfofromConsole(i);
                }
            }
        }

        public Accenture(int Employeeid, string Employeename, string Employeedepartment, string Employeedesignation, string Companyname, double Employeesalary, float Servicecompleted)
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
            double EmployerPF = (BasicSalary * 12) / 100;
            Console.WriteLine("Employee Contribution : " + (EmployeePF + EmployerPF));
            return (EmployeePF + EmployerPF);
        }



        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            Console.WriteLine("Gratuity Amount Not Applicable");
            return 0;
        }

        public string LeaveDetails()
        {
            String Leavedetails = "1 day of Casual Leave per month" + " " + "12 days of Sick Leave per year" + " " + "10 days of Privilege Leave per year";
            Console.WriteLine("Leave Details : 1 day of Casual Leave per month, 12 days of Sick Leave per year, 10 days of Privilege Leave per year");
            return Leavedetails;
        }

        public void DetailsShowcase()
        {
            for (int i = 0; i < AccEmployees.Length; i++)
            {
                Result result = new Result();
                result.ResultDetails(AccEmployees[i], AccEmployees[i].ServiceCompleted, AccEmployees[i].EmployeeBasicSalary);
            }
        }
    }
}
