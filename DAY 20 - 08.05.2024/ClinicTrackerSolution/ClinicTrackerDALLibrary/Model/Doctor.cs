using System;
using System.Collections.Generic;

namespace ClinicTrackerDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Specialization { get; set; }
        public int? Experience { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
