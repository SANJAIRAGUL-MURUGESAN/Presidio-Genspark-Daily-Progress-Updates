using ClinicTrackerAPI.Exceptions;
using ClinicTrackerAPI.Interfaces;
using ClinicTrackerAPI.Models;

namespace ClinicTrackerAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<Doctor> GetDoctorBySpecialization(string specialization)
        {
                var doctor = (await _repository.Get()).FirstOrDefault(d => d.Specialization == specialization);
                if (doctor == null)
                    throw new NoSuchDoctorFoundException();
                return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, float experience)
        {
                var doctor = await _repository.Get(id);
                if (doctor == null)
                    throw new NoSuchDoctorFoundException();
                doctor.Experience = experience;
                var resulteddoctor = await _repository.Update(doctor);
                return resulteddoctor;
        }
    }
}
