using ClinicTrackerDALLibrary.Model;
using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class PatientRepository : IRepository<int, Model.Patient>
    {

        dbClinicTrackerContext _context;
        public PatientRepository(dbClinicTrackerContext context)
        {
            _context = context;
        }
        public Model.Patient Add(Model.Patient item)
        {
            if (!_context.Patients.Any(a => a.PatientName == item.PatientName))
            {
                _context.Patients.Add(item);
                _context.SaveChanges();
                return item;
            }
            return null;
        }
        public Model.Patient Delete(int key)
        {
            var patient = _context.Patients.Find(key);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return patient;
            }
            return null;
        }
        public Model.Patient Get(int key)
        {
            if (_context.Patients.Find(key) != null)
            {
                return _context.Patients.Find(key);
            }
            return null;
        }
        public List<Model.Patient> GetAll()
        {
            if (_context.Patients.ToList() != null)
            {
                return _context.Patients.ToList();
            }
            return null;
        }

        public Model.Patient Update(Model.Patient item)
        {
            var patient = _context.Patients.Find(item.PatientId);
            if (patient != null)
            {
                _context.Entry(patient).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return patient;
            }
            return null;
        }

    }
}
