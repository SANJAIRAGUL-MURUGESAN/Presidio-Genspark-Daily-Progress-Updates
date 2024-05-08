using ClinicTrackerDALLibrary.Model;
using Microsoft.EntityFrameworkCore;
//using ClinicTrackerModelLibrary;
namespace ClinicTrackerDALLibrary
{
    public class DoctorRepository : IRepository<int, Model.Doctor>
    {
        
        dbClinicTrackerContext _context;

        public DoctorRepository(dbClinicTrackerContext context)
        {
            _context = context;
        }

       
        public Model.Doctor Add(Model.Doctor item)
        {
            if (!_context.Doctors.Any(a => a.DoctorName == item.DoctorName))
            {
                _context.Doctors.Add(item);
                _context.SaveChanges();
                return item;
            }
            return null;
        }

        public Model.Doctor Delete(int key)
        {
            var doctor = _context.Doctors.Find(key);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return doctor;
            }
            return null;

        }

        public Model.Doctor Get(int key)
        {
            if (_context.Doctors.Find(key) != null)
            {
                return _context.Doctors.Find(key);
            }
            return null;
        }

        public List<Model.Doctor> GetAll()
        {
            if (_context.Doctors.ToList() != null)
            {
                return _context.Doctors.ToList();
            }
            return null;
        }

        public Model.Doctor Update(Model.Doctor item)
        {
            var doctor = _context.Doctors.Find(item.DoctorId);
            if (doctor != null)
            {
                _context.Entry(doctor).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return doctor;
            }
            return null;
        }
    }
}
