using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    internal class AppointmentBusninessLogic
    {
        readonly IRepository<int, Appointments> _AppointmentRepository;
        public AppointmentBusninessLogic()
        {
            _AppointmentRepository = new AppointmentRepository();
        }
    }
}
