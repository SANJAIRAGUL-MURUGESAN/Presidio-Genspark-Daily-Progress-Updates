using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;

namespace ClinicTrackerBLLibrary
{
    public interface IDoctorsService
    {
        int AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        Doctor DeleteDoctorById(int key);
        Doctor GetDoctorById(int key);
        Doctor ChangeDoctorName(int key, string NewDoctorName);

    }
}
