namespace ClinicTrackerAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Specialization { get; set; }
        public float Experience { get; set; }
    }
}
