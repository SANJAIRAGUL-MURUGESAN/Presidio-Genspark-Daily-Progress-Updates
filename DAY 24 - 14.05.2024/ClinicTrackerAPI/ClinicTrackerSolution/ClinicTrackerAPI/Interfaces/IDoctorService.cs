using ClinicTrackerAPI.Models;

namespace ClinicTrackerAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<Doctor> GetDoctorBySpecialization(string specialization);
        public Task<Doctor> UpdateDoctorExperience(int id, float experience);
        public Task<IEnumerable<Doctor>> GetDoctors();
    }
}
