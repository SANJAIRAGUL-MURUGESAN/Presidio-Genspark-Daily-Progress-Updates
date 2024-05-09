using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;
using ClinicAppointmentBLLibrary;
using System.Numerics;
using ClinicTrackerBLLibrary;
using ClinicTrackerBLLibrary.Exceptions;

namespace ClinicTrackerBLTests
{
    public class Tests
    {
        IRepository<int, Doctor> repository;
        IDoctorsService doctorServices;
        [SetUp]
        public void Setup()
        {
            var dbContext = new dbClinicTrackerContext();
            repository = new DoctorRepository(dbContext);
            doctorServices = new DoctorBusinessLogic(repository);
        }

        [Test]
        public void AddDoctorSuccessTest()
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                DoctorId = 103,
                DoctorName = "Dr. Riyaz",
                Gender = "Male",
                Specialization = "MD",
                Experience = 15,
                DateOfBirth = DateTime.Parse("2000-04-14")
            };
            //Action
            var result = doctorServices.AddDoctor(newDoctor);

            //Assert
            Assert.AreEqual(103, result);
        }

        [Test]
        public void AddDoctorExceptionTest()
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                DoctorId = 103,
                DoctorName = "Dr. Riyaz",
                Gender = "Male",
                Specialization = "MD",
                Experience = 15,
                DateOfBirth = DateTime.Parse("2000-04-14")
            };

            //Action
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorServices.AddDoctor(newDoctor));

            //Assert
            Assert.AreEqual("No Doctor Found!", exception.Message);
        }

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            //Action
            var result = doctorServices.DeleteDoctorById(103);

            //Assert
            Assert.AreEqual(0, result.DoctorId);
        }

        [Test]
        public void DeleteDoctorExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorServices.DeleteDoctorById(210100));
            //Assert
            Assert.AreEqual("No Doctor Found!", exception.Message);
        }

        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            //Action
            var result = doctorServices.GetAllDoctors();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAllDoctorsExceptionTest()
        {
            //Action
            doctorServices.DeleteDoctorById(100);
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorServices.GetAllDoctors());
            //Assert
            Assert.AreEqual("No Doctor Found!", exception.Message);
        }

        [Test]
        public void ChangeDoctorNameSucccessTest()
        {
            //Action
            var result = doctorServices.ChangeDoctorName(104, "Murugesan");

            //Assert
            Assert.AreEqual(result.DoctorName, "Murugesan");
        }

        [Test]
        public void ChangeDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorServices.ChangeDoctorName(1023, "Mathi"));
            //Assert
            Assert.AreEqual("No Doctor Found!", exception.Message);
        }
    }
}