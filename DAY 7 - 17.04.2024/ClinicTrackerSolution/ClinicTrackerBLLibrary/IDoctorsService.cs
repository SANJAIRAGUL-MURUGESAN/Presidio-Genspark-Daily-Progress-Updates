using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public interface IDoctorsService
    {
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        Doctor ChangeDoctorName(int id,string NewDoctorName);
        Doctor ChangeDoctorSpecialization(int id, string NewSpecialization);
        Doctor ChangeDoctorExperience(int id, double newExperience);
        bool DeleteDoctor(int id);
        Doctor ShowDoctorsbasedSpeciality(string specialization, double experience);

    }
}
