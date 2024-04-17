using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    internal class PatientBusinessLogic
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientBusinessLogic()
        {
            _patientRepository = new PatientRepository();
        }
    }
}
