using ClinicTrackerDALLibrary.Model;
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
        int AddAppointment(Appointment appointment);
        List<Appointment> GetAllAppointment();
        Appointment DeleteAppointmentById(int key);
        Appointment GetAppointmentById(int key);

    }
}
