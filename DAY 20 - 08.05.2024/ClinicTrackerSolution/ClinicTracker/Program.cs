using System;
using ClinicTrackerDALLibrary;
using System.Collections.Generic;
using ClinicTrackerDALLibrary.Model;
using ClinicTrackerBLLibrary;
using ClinicAppointmentBLLibrary;
using ClinicTrackerBLLibrary.Exceptions;
//using ClinicTrackerModelLibrary;
//using ClinicTracker;

namespace ClinicAppointmentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Initialize repository and BLL
            var dbContext = new dbClinicTrackerContext();
            var doctorRepository = new DoctorRepository(dbContext);
            var doctorBL = new DoctorBusinessLogic(doctorRepository);

            // Add doctors
            try
            {
                var doctor1 = new Doctor { DoctorName = "Dr. Sanjai", Experience = 10, Specialization = "Cardiology", DateOfBirth = new DateTime(2002, 3, 13),Gender = "Male" };
                int CreatedDoctorId = doctorBL.AddDoctor(doctor1);
                Console.WriteLine($"CreatedDoctorId : {CreatedDoctorId}");
            }
            catch (NoDoctorFoundException Ndfe)
            {
                Console.WriteLine(Ndfe.Message);
            }

            ///Get all doctors
            try
            {
                List<Doctor> allDoctors = doctorBL.GetAllDoctors();
                Console.WriteLine("All Doctors:");
                //PrintDoctors(allDoctors);
            }
            catch (NoDoctorFoundException Ndfe)
            {
                Console.WriteLine(Ndfe.Message);
            }

            // Get doctor by ID
            try
            {
                int doctorId = 101;
                Doctor doctorById = doctorBL.GetDoctorById(doctorId);
                Console.WriteLine($"Doctor with ID {doctorId}: {doctorById.DoctorName}");
            }
            catch (NoDoctorFoundException Ndfe)
            {
                Console.WriteLine(Ndfe.Message);
            }

            // Delete a doctor
            try
            {
                int deletedDoctorId = 101;
                Doctor deletedDoctor = doctorBL.DeleteDoctorById(deletedDoctorId);
                Console.WriteLine($"Deleted doctor with ID {deletedDoctorId}: {deletedDoctor.DoctorName}");
            }
            catch(NoDoctorFoundException Ndfe)
            {
                Console.WriteLine(Ndfe.Message);
            }

            // Change Doctor Name
            try
            {
                string NewDoctorname = "SanjaiRagulM";
                int DoctorId = 102;
                Doctor UpdatedDoctor = doctorBL.ChangeDoctorName(DoctorId, NewDoctorname);
                Console.WriteLine($"Updated Doctor Name : {UpdatedDoctor.DoctorName}");
            }
            catch (NoAppointmentFoundException Nafe)
            {
                Console.WriteLine(Nafe.Message);
            }


            // --------------------- Appointment -----------------

            // Initialize repository and BLL
            //var dbContext = new dbClinicTrackerContext();
            var appointmentRepository = new AppointmentRepository(dbContext);
            var appointmentBL = new AppointmentBusninessLogic(appointmentRepository);

            // Add Appointments
            try
            {
                var appointment = new Appointment { DoctorId = 101, PatientId = 101, AppointmentDate = new DateTime(2024, 06, 13), Disease = "Cold" };
                int CreatedAppointmentId = appointmentBL.AddAppointment(appointment);
                Console.WriteLine($"CreatedAppointmentId : {CreatedAppointmentId}");
            }
            catch(NoAppointmentFoundException Nafe)
            {
                Console.WriteLine(Nafe.Message);
            }

            // Get Appointment By ID
            try
            {
                int AppointmentId = 102;
                Appointment AppointmentbyID = appointmentBL.GetAppointmentById(AppointmentId);
                Console.WriteLine($"Doctor with Appontment {AppointmentId}: {AppointmentbyID.DoctorId}");
            }
            catch(NoAppointmentFoundException Nafe)
            {
                Console.WriteLine(Nafe.Message);
            }

            // Get All Appointments
            try
            {
                List<Appointment> AllAppointments = appointmentBL.GetAllAppointment();
                Console.WriteLine("All Appointments:");
                //PrintDoctors(allDoctors);
            }
            catch(NoAppointmentFoundException Nafe)
            {
                Console.WriteLine(Nafe.Message);
            }

            // Delete Appointment By Id
            try
            {
                int ToDeleteAppointmentId = 102;
                Appointment deletedApppointment = appointmentBL.DeleteAppointmentById(ToDeleteAppointmentId);
                Console.WriteLine($"Deleted Appointment with ID {ToDeleteAppointmentId}: {deletedApppointment.DoctorId}");
            }
            catch(NoAppointmentFoundException Nafe)
            {
                Console.WriteLine(Nafe.Message);
            }


            // -----------------  Patient ----------------

            // Initialize repository and BLL
            //var dbContext = new dbClinicTrackerContext();
            var patientRepository = new PatientRepository(dbContext);
            var patientBL = new PatientBusinessLogic(patientRepository);

            // Add Patient
            try
            {
                var patient = new Patient{ PatientName = "Ragul", DateOfBirth = new DateTime(2002, 06, 12), Gender = "Male", Email = "sanjairagul@gmail.com" };
                int CreatedPatientId = patientBL.AddPatient(patient);
                Console.WriteLine($"CreatedpatientId : {CreatedPatientId}");
            }
            catch(NoPatientFoundException Npfe)
            {
                Console.WriteLine(Npfe.Message);
            }

            // Get Patient By Id
            try
            {
                int PatientId = 101;
                Patient PatientById = patientBL.GetPatientById(PatientId);
                Console.WriteLine($"Patient with Id {PatientId}: {PatientById.PatientName}");
            }
            catch(NoPatientFoundException Npfe)
            {
                Console.WriteLine(Npfe.Message);
            }

            // Get All Patients
            try
            {
                List<Patient> AllPatients = patientBL.GetAllPatient();
                Console.WriteLine("All Patients:");
                //PrintDoctors(allDoctors);
            }
            catch(NoPatientFoundException Npfe)
            {
                Console.WriteLine(Npfe.Message);
            }

            // Delete Patient By Id
            try
            {
                int ToDeletePateintId = 101;
                Patient deletedPatient = patientBL.DeletePatientById(ToDeletePateintId);
                Console.WriteLine($"Deleted Patient with ID {ToDeletePateintId}: {deletedPatient.PatientName}");
            }
            catch(NoPatientFoundException Npfe)
            {
                Console.WriteLine(Npfe.Message);
            }

            // Change Patient Name
            try
            {
                string NewPatientname = "SanjaiRagulM";
                int PatientId = 107;
                Patient UpdatedPatient = patientBL.ChangePatientName(PatientId, NewPatientname);
                Console.WriteLine($"Updated Patient Name : {UpdatedPatient.PatientName}");
            }
            catch(NoPatientFoundException Npfe)
            {
                Console.WriteLine(Npfe.Message);
            }
        }
    }
}