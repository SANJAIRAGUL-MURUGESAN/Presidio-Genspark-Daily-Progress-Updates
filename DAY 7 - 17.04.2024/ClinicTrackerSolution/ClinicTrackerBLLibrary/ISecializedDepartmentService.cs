using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;

namespace ClinicTrackerBLLibrary
{
    public interface ISecializedDepartmentService
    {
        int AddDepartment(SpecializedDepartment department);
        SpecializedDepartment ChangeDepartmentName(string departmentOldName, string departmentNewName);
        SpecializedDepartment GetDepartmentById(int id);
        SpecializedDepartment GetDepartmentByName(string departmentName);
        int GetDepartmentHeadId(int departmentId);
        bool DeleteSpecializedDepartment(int id);

    }
}
