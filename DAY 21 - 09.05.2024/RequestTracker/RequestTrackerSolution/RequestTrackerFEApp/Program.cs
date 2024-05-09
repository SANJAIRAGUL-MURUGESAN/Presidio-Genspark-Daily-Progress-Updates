using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            EmployeeFrontend Employeefrontend = new EmployeeFrontend();
            Employeefrontend.EmployeeRegister();
            Employeefrontend.EmployeeLogin();


            //Employee employee = new Employee() { Name ="sanjai", Password = "sa", Role="Admin" };
            //IEmployeeService employeeBL = new EmployeeBL();
            //var result = employeeBL.Register(employee);
            //Console.WriteLine(result.Result.Name);
        }
    }
}
