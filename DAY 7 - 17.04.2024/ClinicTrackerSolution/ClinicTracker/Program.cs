using ClinicTrackerModelLibrary;

namespace ClinicTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor(101, "Sanjai", "Male",new DateTime(2000, 12, 2), "HeartSpecialist", 10);
            Nurses nurse = new Nurses(101, "Sanjai", "Male", new DateTime(2000, 12, 2), "HeartSpecialist", 10);
            Patient patient = new Patient(101,"Sanjai","Male", new DateTime(2000, 12, 2),"Sugar");
            //Appointments appointments = new Appointments(101, "Sanjai", "Sugar", "Male", new DateTime(2000, 12, 2), "DoctorName", new DateTime(2024, 20, 4));
            SpecializedDepartment specializeddepartments = new SpecializedDepartment(101,"Sugar","Head_Name");
        }
    }
}
