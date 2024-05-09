using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEApp
{
    public class EmployeeFrontend
    {
        IEmployeeService employeeBL;
        public EmployeeFrontend()
        {
            employeeBL = new EmployeeBL();
        }
        public async Task EmployeeRegister()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Name");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your Password");
            string password = Console.ReadLine() ?? "";
            await Console.Out.WriteLineAsync("Please enter your Role");
            string role = Console.ReadLine() ?? "";
            Employee employee = new Employee() { Name = name, Password = password, Role = role };
            var resultadded = employeeBL.Register(employee);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Register Success with Username: {resultadded.Result.Name}");
            }
            else
            {
                Console.Out.WriteLine("Registeration failed");
            }
        }
        public async Task EmployeeLogin()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            Employee employee = new Employee() { Password = password, Id = id };
            var result = await employeeBL.Login(employee);
            if (result)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }

    }
}
