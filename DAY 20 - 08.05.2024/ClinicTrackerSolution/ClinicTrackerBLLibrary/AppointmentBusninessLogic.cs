using ClinicTrackerDALLibrary;
//using ClinicAppointmentModelLibrary;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ClinicTrackerDALLibrary.Model;
using ClinicTrackerBLLibrary;
using ClinicTrackerModelLibrary;
using ClinicTrackerBLLibrary.Exceptions;

namespace ClinicTrackerBLLibrary
{
    public class AppointmentBusninessLogic : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentRepository;
        public AppointmentBusninessLogic(IRepository<int, Appointment> appointmentRepository)
        {
            //_doctorRepository=new DoctorRepository();
            _appointmentRepository = appointmentRepository;
        }

        public int AddAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Add(appointment);
            if (result != null)
            {
                return result.AppointmentId;
            }
            throw new NoAppointmentFoundException();
        }

        public Appointment DeleteAppointmentById(int key)
        {
            var deletedAppointment = _appointmentRepository.Delete(key);
            if (deletedAppointment != null)
            {
                return deletedAppointment;

            }
            throw new NoAppointmentFoundException();
        }

        public List<Appointment> GetAllAppointment()
        {
            var appointments = _appointmentRepository.GetAll();
            if (appointments != null)
            {
                return appointments;
            }
            throw new NoAppointmentFoundException();
        }

        public Appointment GetAppointmentById(int key)
        {
            var appointment = _appointmentRepository.GetAll();
            for (int i = 0; i < appointment.Count; i++)
                if (appointment[i].AppointmentId == key)
                    return appointment[i];
            throw new NoAppointmentFoundException();
        }
    }
}
