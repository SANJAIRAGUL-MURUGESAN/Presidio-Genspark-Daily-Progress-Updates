using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public interface IPatientService
    {
        int AddPatient(Patient patient);
        Patient GetPatient(int id);
        Patient ChangePatientName(int id);
        Patient ChangeMajorDisease(int id, string NewDisease);
        bool DeletePatients(int id);
        Doctor ShowSpeciality(string Specialization, double experience);

    }
}
