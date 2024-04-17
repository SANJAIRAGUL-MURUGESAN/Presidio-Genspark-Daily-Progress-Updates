using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public interface INursesService
    {
        int AddNurse(Nurses nurse);
        Nurses ChangeNurseName(int id, string NewName);
        Nurses ChangeSpecialization(int id, string NewSpecialization);
        Nurses ChangeExperience(int id, double NewExperience);
        bool DeleteNurses(int id);
    }
}
