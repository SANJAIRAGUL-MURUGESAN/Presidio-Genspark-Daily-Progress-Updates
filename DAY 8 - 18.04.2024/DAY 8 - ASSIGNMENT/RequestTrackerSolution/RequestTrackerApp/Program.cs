
using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.DepartmentExceptions;
using RequestTrakerModelLibrary;
using System.Collections;
using System.Globalization;
using System.Xml.Linq;

namespace RequestTrackerApp
{
    internal class Program
    {
        DepartmentBL departmentBL = new DepartmentBL();
        EmployeeBL employeeBL = new EmployeeBL();
        void AddDepartment()
        {
            try
            {
                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Pleae enter the department name");
                name = Console.ReadLine();
                department = new Department() { Name = name };
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is "+id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }

        void ChangeDepartmentName()
        {
            try
            {
                Console.WriteLine("Pleae enter the department old name");
                string OldName = Console.ReadLine();
                Console.WriteLine("Pleae enter the department new name");
                string Newname = Console.ReadLine();
                string UpdatedName = departmentBL.ChangeDepartmentName(OldName, Newname).Name;
                Console.Write("Updated Name of the Departname : " + UpdatedName);
            }catch(NoDepartmentFoundException ndfe)
            {
                Console.WriteLine(ndfe.Message);
            }
        }

        void GetDepartmentbyID()
        {
            try
            {
                Console.WriteLine("Please enter the ID of Department:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(departmentBL.GetDepartmentById(id).Name);
            }catch(NoDepartmentFoundException ndfe)
            {
                Console.WriteLine(ndfe.Message);
            }
        }

        void GetDepartmentByName()
        {
            try
            {
                Console.WriteLine("Please enter the Name of Department:");
                string Name = Console.ReadLine();
                Console.WriteLine(departmentBL.GetDepartmentByName(Name).Id);
            }
            catch (NoDepartmentFoundException ndfe)
            {
                Console.WriteLine(ndfe.Message);
            }
        }

        void GetDepartmentHeadID()
        {
            try
            {
                Console.WriteLine("Enter the Department ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(departmentBL.GetDepartmentHeadId(id));
            }
            catch (NoDepartmentFoundException ndfe)
            {
                Console.WriteLine(ndfe.Message);
            }
            
        }

        void GetDepartmentList()
        {
            departmentBL.GetDepartmentList();
            Console.WriteLine(departmentBL.GetDepartmentList().ToList());
        }

        void EmployeeOperations()
        {
            EmployeeFrontend Employeefrontend = new EmployeeFrontend();
            Employeefrontend.AddEmployee();
            Employeefrontend.ChangeEmployeeName();
            Employeefrontend.GetEmployeebyId();
            Employeefrontend.GetEmployeebyname();
            Employeefrontend.GetEmployeelist();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddDepartment();
            program.ChangeDepartmentName();
            program.GetDepartmentbyID();
            program.GetDepartmentByName();
            program.GetDepartmentHeadID();
            program.GetDepartmentList();
            program.EmployeeOperations();
        }
    }
}
