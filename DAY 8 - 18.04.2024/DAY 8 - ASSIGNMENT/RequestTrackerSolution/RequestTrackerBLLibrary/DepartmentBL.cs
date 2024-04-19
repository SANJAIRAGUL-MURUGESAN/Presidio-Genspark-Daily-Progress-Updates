using RequestTrackerBLLibrary.DepartmentExceptions;
using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);
            
            if(result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            List<Department> list = _departmentRepository.GetAll();
            if(list != null)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == departmentOldName)
                    {
                        list[i].Name = departmentNewName;
                        _departmentRepository.Update(list[i]);
                        return list[i];
                    }
                    
                }
            }
            throw new NoDepartmentFoundException();
        }

        public Department GetDepartmentById(int id)
        {
            var result = _departmentRepository.Get(id);
            if(result != null)
            {
                return result;
            }
            throw new NoDepartmentFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            List<Department> list = _departmentRepository.GetAll();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == departmentName)
                    {
                        var result = _departmentRepository.Get(list[i].Id);
                        return result;
                    }
                }
            }
            throw new NoDepartmentFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var result = _departmentRepository.Get(departmentId);
            if (result != null)
            {
                return result.Department_HeadId;
            }
            throw new NoDepartmentFoundException();
        }

        public List<Department> GetDepartmentList()
        {
            List<Department> list = _departmentRepository.GetAll();
            if(list != null)
            {
                return list;
            }
            throw new NotImplementedException();
        }
    }
}
