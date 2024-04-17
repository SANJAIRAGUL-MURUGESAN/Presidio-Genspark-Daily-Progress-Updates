using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public interface IAppointmentService
    {
        int AddAppointment(Appointments appointments);
        Appointments ChangeAppointmentDate(int id, DateTime date);
        Appointments ChangeAppointmenttoDoctors(int id, string NewDoctorName);
        Appointments GetAllAppointmentsofPatient(string Patientname); // (int id)
        Appointments GetAllAppointmentsofDoctor(string Doctorname); // (int id)
        Appointments GetAllAppointmentsofPatientforParticularYear(int id, int year);
        Appointments GetAllAppointmentsofPatientforParticularMonth_Year(int id, int year, int month);
        Appointments GetAllAppointmentsofDoctorforParticularYear(int id, int year);
        Appointments GetAllAppointmentsofDoctorforParticularMonth_Year(int id, int year);
        Appointments GetAllAppointmentsforDiseaseInYear(string Disease, int year);
        bool DeleteAppointments(int id);

    }
}
