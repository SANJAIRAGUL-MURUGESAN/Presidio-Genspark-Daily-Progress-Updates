using ClinicTrackerBLLibrary.Exceptions;
using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public class PatientBusinessLogic : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientBusinessLogic(IRepository<int, Patient> patientRepository)
        {
            //_doctorRepository=new DoctorRepository();
            _patientRepository = patientRepository;
        }

        public int AddPatient(Patient patient)
        {
            var result = _patientRepository.Add(patient);
            if (result != null)
            {
                return result.PatientId;
            }
            throw new NoPatientFoundException();
        }

        public Patient DeletePatientById(int key)
        {
            var deletedPatient = _patientRepository.Delete(key);
            if (deletedPatient != null)
            {
                return deletedPatient;

            }
            throw new NoPatientFoundException();
        }

        public List<Patient> GetAllPatient()
        {
            var patients = _patientRepository.GetAll();
            if (patients != null)
            {
                return patients;
            }
            throw new NoPatientFoundException();
        }

        public Patient GetPatientById(int key)
        {
            var patients = _patientRepository.GetAll();
            for (int i = 0; i < patients.Count; i++)
                if (patients[i].PatientId == key)
                    return patients[i];
            throw new NoPatientFoundException();
        }

        public Patient ChangePatientName(int key, string NewPatientname)
        {
            var patients = _patientRepository.Get(key);
            if(patients != null)
            {
                patients.PatientName = NewPatientname;
                return _patientRepository.Update(patients);
            }
            throw new NoPatientFoundException();
        }
    }
}
