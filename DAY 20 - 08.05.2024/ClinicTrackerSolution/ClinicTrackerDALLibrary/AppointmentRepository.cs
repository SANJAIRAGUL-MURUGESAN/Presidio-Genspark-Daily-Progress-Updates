using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int, Model.Appointment>
    {
        dbClinicTrackerContext _context;

        public AppointmentRepository(dbClinicTrackerContext context)
        {
            _context = context;
        }


        public Model.Appointment Add(Model.Appointment item)
        {
            if (!_context.Appointments.Any(a => a.AppointmentId == item.AppointmentId))
            {
                _context.Appointments.Add(item);
                _context.SaveChanges();
                return item;
            }
            return null;
        }

        public Model.Appointment Delete(int key)
        {
            var appointment = _context.Appointments.Find(key);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return appointment;
            }
            return null;

        }

        public Model.Appointment Get(int key)
        {
            if (_context.Appointments.Find(key) != null)
            {
                return _context.Appointments.Find(key);
            }
            return null;
        }

        public List<Model.Appointment> GetAll()
        {
            if (_context.Appointments.ToList() != null)
            {
                return _context.Appointments.ToList();
            }
            return null;
        }

        public Model.Appointment Update(Model.Appointment item)
        {
            var appointment = _context.Appointments.Find(item.AppointmentId);
            if (appointment != null)
            {
                _context.Entry(appointment).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return appointment;
            }
            return null;
        }
       
    }
}
