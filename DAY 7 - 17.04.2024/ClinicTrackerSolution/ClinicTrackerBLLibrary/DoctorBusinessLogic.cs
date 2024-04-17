using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
namespace ClinicAppointmentBLLibrary
{
    public class DoctorBusinessLogic
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBusinessLogic()
        {
            _doctorRepository = new DoctorRepository();
        }
    }
}