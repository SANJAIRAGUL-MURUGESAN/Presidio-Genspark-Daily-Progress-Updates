using ClinicTrackerDALLibrary.Model;
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
        List<Patient> GetAllPatient();
        Patient DeletePatientById(int key);
        Patient GetPatientById(int key);
        Patient ChangePatientName(int key, string NewPatientname);

    }
}
