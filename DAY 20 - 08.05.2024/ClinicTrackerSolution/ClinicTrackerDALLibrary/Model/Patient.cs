using System;
using System.Collections.Generic;

namespace ClinicTrackerDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
