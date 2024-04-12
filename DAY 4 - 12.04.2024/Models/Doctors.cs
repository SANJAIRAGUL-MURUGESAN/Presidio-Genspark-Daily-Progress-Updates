using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnderstandingBasicsApp.Models
{
    internal class Doctors
    {
        private int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DoctorAge { get; set; }
        public int DoctorExperience { get; set; }
        public string DoctorQualification { get; set; }
        public string DoctorSpeciality { get; set; }

        /// <summary>
        /// Function to create a Doctor Object by getting inputs from the user or console!
        /// </summary>
        /// <param name="id">Doctor ID Generation</param>
        /// <returns></returns>
        public Doctors CreateDoctorByTakingDetailsFromConsole(int id)
        {
            Doctors doctor = new Doctors();
            doctor.DoctorId = id;
            Console.WriteLine("Please enter the Doctor Name : ");
            doctor.DoctorName = Console.ReadLine();
            Console.WriteLine("Please enter the age of the Doctor : ");
            doctor.DoctorAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the qualification of the Doctor : ");
            doctor.DoctorQualification = Console.ReadLine();
            Console.WriteLine("Please enter the experience of the Doctor : ");
            doctor.DoctorExperience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Speciality of the Doctor : ");
            doctor.DoctorSpeciality = Console.ReadLine();
            return doctor;
        }

        /// <summary>
        /// Function to Print the Doctor Details
        /// </summary>
        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Doctor ID : {DoctorId}");
            Console.WriteLine($"Doctor Name : {DoctorName}");
            Console.WriteLine($"Doctor Age : {DoctorAge}");
            Console.WriteLine($"Doctor Qualification : {DoctorQualification}");
            Console.WriteLine($"Doctor Experiece : {DoctorExperience}");
            Console.WriteLine($"Doctor Speciality : {DoctorSpeciality}");
        }

        /// <summary>
        /// Function to check any doctors available with provided speciality
        /// </summary>
        /// <param name="Speciality">Speciality of the Doctor</param>
        /// <returns></returns>
        public int FindDoctorByProvidedSpeciality(string Speciality)
        {
            if(DoctorSpeciality == Speciality)
            {
                Console.WriteLine($"Doctor ID : {DoctorId}");
                Console.WriteLine($"Doctor Name : {DoctorName}");
                Console.WriteLine($"Doctor Age : {DoctorAge}");
                Console.WriteLine($"Doctor Qualification : {DoctorQualification}");
                Console.WriteLine($"Doctor Experiece : {DoctorExperience}");
                Console.WriteLine($"Doctor Speciality : {DoctorSpeciality}");
                return 1;
            }
            return 0;
        }

    }
}
