using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.DepartmentExceptions;
using RequestTrackerBLLibrary.EmployeeExceptions;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApp
{
    public class EmployeeFrontend
    {
        EmployeeBL employeeBL = new EmployeeBL();
        public void AddEmployee()
        {
            try
            {
                Console.WriteLine("Pleae enter the Employee name");
                string name = Console.ReadLine();
                Employee employee = new Employee() { Name = name };
                int id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the Employee for you and the Id is " + id);
                Console.WriteLine("Pleae enter the Employee name");
                name = Console.ReadLine();
                employee = new Employee() { Name = name };
                id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the Employee for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        public void ChangeEmployeeName()
        {
            try
            {
                Console.WriteLine("Enter the Old Name of Employee : ");
                string Oldname = Console.ReadLine();
                Console.WriteLine("Enter the New Name of Employee : ");
                string Newname = Console.ReadLine();
                string updatedName = employeeBL.ChangeEmployeeName(Oldname, Newname).Name;
                Console.WriteLine(updatedName);
            }catch(NoEmployeeFoundException nefe)
            {
                Console.WriteLine(nefe.Message);
            }
        }

        public void GetEmployeebyId()
        {
            try
            {
                Console.WriteLine("Enter the ID of Employee : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(employeeBL.GetEmployeeById(id).Name);
            }catch(NoEmployeeFoundException nefe)
            {
                Console.WriteLine(nefe.Message);
            }
        }

        public void GetEmployeebyname()
        {
            try
            {
                Console.WriteLine("Enter the name of Employee : ");
                string Employeename = Console.ReadLine();
                Console.WriteLine("Employee ID" + (employeeBL.GetEmployeeByName(Employeename).Id));
            }catch(NoEmployeeFoundException nefe)
            {
                Console.WriteLine(nefe.Message);
            }
        }

        public void GetEmployeelist()
        {
            try
            {
                Console.WriteLine(employeeBL.GetEmployeeList().ToList());
            }catch(NoEmployeeFoundException nefe)
            {
                Console.WriteLine(nefe.Message);
            }
        }
    }
}
