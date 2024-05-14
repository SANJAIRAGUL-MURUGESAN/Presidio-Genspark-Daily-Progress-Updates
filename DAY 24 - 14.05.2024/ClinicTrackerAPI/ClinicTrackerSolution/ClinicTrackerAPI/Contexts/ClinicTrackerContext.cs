using ClinicTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicTrackerAPI.Contexts
{
    public class ClinicTrackerContext : DbContext
    {
        public ClinicTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Email = "ramu@gmail.com", Designation = "MD", Specialization="Heart", Experience = 12 },
                new Doctor() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Email = "somu@gmail.com", Designation = "MBBS", Specialization="Sugar", Experience = 8 }
                );
        }
    }
}
