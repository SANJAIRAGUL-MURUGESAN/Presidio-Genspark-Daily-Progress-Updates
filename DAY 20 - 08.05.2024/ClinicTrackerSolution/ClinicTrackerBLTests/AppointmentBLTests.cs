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
    public class AppointmentBLTests
    {
        IRepository<int, Appointment> repository;
        IAppointmentService appointmentServices;
        [SetUp]
        public void Setup()
        {
            var dbContext = new dbClinicTrackerContext();
            repository = new AppointmentRepository(dbContext);
            appointmentServices = new AppointmentBusninessLogic(repository);
        }
        [Test]
        public void AddAppointmentSuccessTest()
        {
            //Arrange
            Appointment appointment = new Appointment()
            {
                AppointmentId = 202,
                AppointmentDate = DateTime.Parse("2024-06-04"),
                DoctorId = 103,
                PatientId = 109,
                Disease = "Cold",
            };
            //Action
            var result = appointmentServices.AddAppointment(appointment);

            //Assert
            Assert.AreEqual(103, result);
        }

        [Test]
        public void AddAppointmentExceptionTest()
        {
            //Arrange
            Appointment appointment = new Appointment()
            {
                AppointmentId = 200,
                AppointmentDate = DateTime.Parse("2024-05-04"),
                DoctorId = 102,
                PatientId = 108,
                Disease = "Cold",
            };

            //Action
            var exception = Assert.Throws<NoAppointmentFoundException>(() => appointmentServices.AddAppointment(appointment));

            //Assert
            Assert.AreEqual("No Appointment Found!", exception.Message);
        }

        [Test]
        public void DeleteAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.DeleteAppointmentById(200);

            //Assert
            Assert.AreEqual(200, result.AppointmentId);
        }

        [Test]
        public void DeleteAppointmentExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoAppointmentFoundException>(() => appointmentServices.DeleteAppointmentById(200));

            //Assert
            Assert.AreEqual("No Appoinment Found!", exception.Message);
        }

        [Test]
        public void GetAllAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.GetAllAppointment();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAppointmentByIDSuccessTest()
        {
            //Action
            var appointment = appointmentServices.GetAppointmentById(101);
            //Assert
            Assert.AreEqual(appointment.AppointmentId, 200);
        }

        [Test]
        public void GetAppointmentByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoAppointmentFoundException>(() => appointmentServices.GetAppointmentById(098));
            //Assert
            Assert.AreEqual("No Appoinment Found!", exception.Message);
        }

    }

}
