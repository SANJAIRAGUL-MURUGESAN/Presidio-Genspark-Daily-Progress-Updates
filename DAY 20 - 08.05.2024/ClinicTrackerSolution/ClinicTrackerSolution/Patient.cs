using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class Patient
    {

        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
            }
        }

        public Patient()
        {
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            DateOfBirth = new DateTime();
            Email = string.Empty;
        }
        public Patient(int id, string name,string gender, DateTime dateOfBirth, string email)
        {
            Id = id;
            Name = name;
            Gender = Gender;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }
}
