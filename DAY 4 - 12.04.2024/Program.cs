using System.ComponentModel.DataAnnotations;
using UnderstandingBasicsApp.Models;

namespace UnderstandingBasicsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee employee = new Employee();
            //Arrays array = new Arrays();

            //employee.Id = 101;
            //employee.Name = "Sanjai Ragul";
            //employee.Salary = 25000;
            //employee.DateOfBirth = new DateTime(2000, 12, 25);
            //employee.Email = "sanjairagul@abc.com";

            //Employee employee2 = new Employee()
            //{
            //    Name = "Ramu",
            //    Salary = 25000,
            //    DateOfBirth = new DateTime(2000, 12, 24),
            //    Email = "ramu@abc.com"
            //};

            //Employee employee3 = new Employee(103, "Somu", 123423, new DateTime(2000, 12, 26), "somu@abc.com");

            //Console.WriteLine(employee3.Id + " " + employee3.Name);
            //Console.WriteLine(employee2.Name);

            //array.ArrayFunction();

            //Employee[] employees = new Employee[3];
            //for (int i = 0; i < employees.Length; i++)
            //{
            //    employees[i] = employee.CreateEmployeeByTakingDetailsFromConsole(101 + i);
            //}

            // ASSIGNMENT - DOCTOR - 12.04.2024

            Doctors doctor = new Doctors();

            Doctors[] doctors = new Doctors[2];

            // For Loop to get input about doctor details

            for(int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = doctor.CreateDoctorByTakingDetailsFromConsole(101 + i);
            }

            // For Loop to print Doctor Details

            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i].PrintDoctorDetails();
            }

            //To Get the Speciality from User to Provide doctors
            Console.WriteLine("Please Enter your required Speciality : ");
            string DoctorSpeciality = Console.ReadLine();
            int Flag = 0;

            Console.WriteLine("Here We go with Doctors matching provided Speciality : ");

            //To find out the doctors matching the provided speciality
            for (int i = 0; i < doctors.Length; i++)
            {
                int count = doctors[i].FindDoctorByProvidedSpeciality(DoctorSpeciality);
                if(count > 0)
                {
                    Flag = 1;
                }
            }

            if (Flag == 0)
            {
                Console.WriteLine("Sorry! We cant you no doctors matching your speciality requirement!");
            }

            // To find a Car Nummber is Valid or Not
            ValidCar validcar = new ValidCar();
            validcar.IsValidCar();


        }
    }
}
