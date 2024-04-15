using System.ComponentModel.DataAnnotations;
using EmployeeRequestTrackerModelLibrary;

namespace EmployeeRequestTrackerApp
{
    internal class Program
    {
        void UnderstandingSequenceStatements()
        {
            Console.WriteLine("Hello!");
            int num1 = 100;
            int num2 = 5;
            int num3 = num1 / num2;
            Console.WriteLine($"{num1} Divided by {num2} is {num3}");
        }

        void UnderstandingSequenceWithIf()
        {
            string Strname = "Somu";
            if(Strname == "Ramu")
            {
                Console.WriteLine($"Welcome {Strname}");
            }
            else if(Strname == "Somu")
            {
                Console.WriteLine($"Welcome {Strname}! You is Some so only Basic Access.");
            }
            else{
                Console.WriteLine("Invalid User,Please Get Out"!);
            }
        }

        void UnderstandingSwitchCase()
        {
            Console.WriteLine("Please Enter the Input : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1 : Console.WriteLine("Its Monday!");
                    break;
                case 2: Console.WriteLine("Its Tuesday!");
                    break;
                default: Console.WriteLine("Invalid Input!");
                    break;
            }
        }

        void UnderstandingInterationWithFor()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("The I valus is "+i);
            }
        }

        void UnderstandingInterationWithWhile()
        {
            int count = 10;
            while (count > 0)
            {
                if(count == 2)
                {
                    break;
                }else if(count == 7)
                {
                    count--;
                    continue;
                }
                else
                {
                    Console.WriteLine("The value of I is" + count);
                }
                count--;
                
            }
        }

        /// Employee Creation and Printing <summary>

        Employee[] employees;
        public Program()
        {
            employees = new Employee[1];
        }

        /// <summary>
        /// Function to get Choice of operation from User
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print All Employees");
            Console.WriteLine("3. Search and Print Employee Details");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
        }

        /// <summary>
        /// Function to make operation based on the choice provied by the User 
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        SearchAndUpdateEmployeeName();
                        break;
                    case 5:
                        SearchAndDeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        /// <summary>
        /// Function to create a Employee Object by validating all Edge cases and storing in the Array 
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }

        /// <summary>
        /// Function to Print the available Employee Details in the Array 
        /// </summary>
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        /// <summary>
        /// Internal Function for creating a Employee Object through Model Library
        /// </summary>
        /// <param name="id">ID for every user without getting from user(Console)/param>
        /// <returns></returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        /// <summary>
        /// Internal Function to Print the available Employee Details in the Array
        /// </summary>
        /// <param name="employee">Employee Object</param>
        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }

        void SearchAndUpdateEmployeeName()
        {
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            Console.WriteLine("Enter the Name to be Updated : ");
            string UpdatedName = Console.ReadLine();
            employee.UpdateEmployeeName(UpdatedName);
            Console.WriteLine("Updated Details of the Employee : ");
            PrintEmployee(employee);
        }

        void SearchAndDeleteEmployee()
        {
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            int Flag = employee.DeleteEmployee(employees, id);
            if(Flag == 0)
            {
                Console.WriteLine($"Employee {employee.Name} is Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("There is a Error in Deleting the Employee! Please,Try again!");
            }
        }

        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }



        static void Main(string[] args)
        {
            Program program = new Program();

            /// Understanding Sequence Statements
            //program.UnderstandingSequenceStatements();
            //program.UnderstandingSequenceWithIf();
            //program.UnderstandingSwitchCase();
            //program.understandinginterationwithfor();
            //program.UnderstandingInterationWithWhile();

            ///Understaning Array///
            Array array = new Array();
            //array.UnderstandingArray();

            /// Creating Employee Object using Model Library and CRUD Operations
            program.EmployeeInteraction();

            /// Cow Bull Game
            CowBull cowbull = new CowBull();
            cowbull.StartGame();

        }
    }
}
