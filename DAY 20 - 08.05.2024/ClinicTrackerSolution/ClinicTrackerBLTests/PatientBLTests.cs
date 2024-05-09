using ClinicAppointmentBLLibrary;
using ClinicTrackerBLLibrary;
using ClinicTrackerDALLibrary.Model;
using ClinicTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicTrackerBLLibrary.Exceptions;

namespace ClinicTrackerBLTests
{
    public class PatientBLTests
    {
        IRepository<int, Patient> repository;
        IPatientService patientServices;
        [SetUp]
        public void Setup()
        {
            var dbContext = new dbClinicTrackerContext();
            repository = new PatientRepository(dbContext);
            patientServices = new PatientBusinessLogic(repository);
        }

        [Test]
        public void AddPatientSuccessTest()
        {
            Patient patient = new Patient()
            {
                PatientId = 102,
                PatientName = "Somu",
                DateOfBirth = DateTime.Parse("2002 - 03 - 13"),
                Gender = "Male",
                Email = "sanjairagulm@gmail.com"
            };
            //Action
            var result = patientServices.AddPatient(patient);

            //Assert
            Assert.AreEqual(105, result);
        }
        [Test]
        public void AddPatientExceptionTest()
        {
            //Arrange
            Patient patient = new Patient()
            {
                PatientId = 102,
                PatientName = "Somu",
                DateOfBirth = DateTime.Parse("2002 - 03 - 13"),
                Gender = "Male",
                Email = "sanjairagulm@gmail.com"
            };

            //Action
            var exception = Assert.Throws<NoPatientFoundException>(() => patientServices.AddPatient(patient));

            //Assert
            Assert.AreEqual("No Patient Found!", exception.Message);
        }
        [Test]
        public void GetPatientByIdSuccesTest()
        {
            //Action
            var patient = patientServices.GetPatientById(102);
            //Assert
            Assert.AreEqual(patient.PatientId,102);
        }

        [Test]
        public void GetDoctorByidExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoPatientFoundException>(() => patientServices.GetPatientById(45678));
            //Assert
            Assert.AreEqual("Patient Not Found!", exception.Message);
        }

        [Test]
        public void DeletePatientSuccessTest()
        {
            //Action
            var result = patientServices.DeletePatientById(105);

            //Assert
            Assert.AreEqual(105, result.PatientId);
        }

        [Test]
        public void DeletePatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoPatientFoundException>(() => patientServices.DeletePatientById(1761));
            //Assert
            Assert.AreEqual("No Patient Found!", exception.Message);
        }

        [Test]
        public void GetAllPatientSuccessTest()
        {
            //Action
            var result = patientServices.GetAllPatient();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAllPatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoPatientFoundException>(() => patientServices.GetAllPatient());
            //Assert
            Assert.AreEqual("No Patient Found!", exception.Message);
        }

        [Test]
        public void ChangePatientNameSucccessTest()
        {
            //Action
            var result = patientServices.ChangePatientName(102, "SanjaiMurugesan");

            //Assert
            Assert.AreEqual(result.PatientName, "Sai");
        }
        public void ChangePatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoPatientFoundException>(() => patientServices.ChangePatientName(13446, "SanjaiMurugesan"));
            //Assert
            Assert.AreEqual("No Patient Found!", exception.Message);
        }
    }
}
