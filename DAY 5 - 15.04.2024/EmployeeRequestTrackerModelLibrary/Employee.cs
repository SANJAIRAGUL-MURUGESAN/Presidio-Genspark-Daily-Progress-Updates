using System.Security.Cryptography.X509Certificates;

namespace EmployeeRequestTrackerModelLibrary
{
    public class Employee
    {
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public double Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
        }
        public Employee(int id, string name, DateTime dateOfBirth, double salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please Enter the Name of the Employee : ");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter the Date of Birth of the Employee : ");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please Enter the Basic Salary of the Employee : ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Function to Print the Employee Details 
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }

        public void UpdateEmployeeName(string NewName)
        {
            Name = NewName;
        }

        public int DeleteEmployee(Employee[] employees, int id)
        {
            int FirstCount = employees.Length;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                    break;
                }
            }
            int SecondCount = employees.Length;
            if(FirstCount < SecondCount)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
