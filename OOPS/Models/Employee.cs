using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0;
            DateOfBirth = DateTime.MinValue;
            Email = string.Empty;
        }

        public Employee(int id)
        {
            Id = id;
        }

        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email) : this(id)
        {
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
        /// <summary>
        /// Displays the Details of Particular Employee
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {Id}");
            Console.WriteLine($"Emplyee Name : {Name}");
            Console.WriteLine($"Employee Salary : {Salary}");
            Console.WriteLine($"Employee Date of Birth : {DateOfBirth}");
            Console.WriteLine($"Employee Email : {Email}");
        }

        public void Work(string name)
        {
            Console.WriteLine($" Name of the Employee : {name}");
        }

        public Employee CreateEmployeeByTakingDetailsFromConsole(int id)
        {
            Employee employee = new Employee(id);
            Console.WriteLine("Please enter the emplyee name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Please enterthe employee Date of Birth");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            employee.Salary = salary;
            Console.WriteLine("Please enter the employee email");
            employee.Email = Console.ReadLine();
            return employee;
        }


    }
}
