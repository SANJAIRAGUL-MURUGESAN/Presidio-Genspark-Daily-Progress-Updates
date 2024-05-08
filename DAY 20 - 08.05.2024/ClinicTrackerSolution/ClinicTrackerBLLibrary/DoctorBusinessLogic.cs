using ClinicTrackerDALLibrary;
//using ClinicAppointmentModelLibrary;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ClinicTrackerDALLibrary.Model;
using ClinicTrackerBLLibrary;
using ClinicTrackerBLLibrary.Exceptions;


namespace ClinicAppointmentBLLibrary
{
    public class DoctorBusinessLogic : IDoctorsService
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBusinessLogic(IRepository<int, Doctor> doctorRepository)
        {
            //_doctorRepository=new DoctorRepository();
            _doctorRepository = doctorRepository;
        }

        public int AddDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);
            if (result != null)
            {
                return result.DoctorId;
            }
            throw new NoDoctorFoundException();
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAll();
            if (doctors != null)
            {
                return doctors;
            }
            throw new NoDoctorFoundException();
        }

        public Doctor DeleteDoctorById(int doctorID)
        {
            var deletedDoctor = _doctorRepository.Delete(doctorID);
            if (deletedDoctor != null)
            {
                return deletedDoctor;

            }
            throw new NoDoctorFoundException();
        }
        public Doctor GetDoctorById(int id)
        {
            var doctors = _doctorRepository.GetAll();
            for (int i = 0; i < doctors.Count; i++)
                if (doctors[i].DoctorId == id)
                    return doctors[i];
            throw new NoDoctorFoundException();
        }
        public Doctor ChangeDoctorName(int key, string NewDoctorName)
        {
            var doctor = _doctorRepository.Get(key);
            if (doctor != null)
            {
                doctor.DoctorName = NewDoctorName;
                return _doctorRepository.Update(doctor);
            }
            throw new NoDoctorFoundException();
        }
    }
}