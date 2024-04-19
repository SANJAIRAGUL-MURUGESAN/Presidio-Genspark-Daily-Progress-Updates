using RequestTrackerBLLibrary.DepartmentExceptions;
using RequestTrackerBLLibrary.EmployeeExceptions;
using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Employee ChangeEmployeeName(string employeeOldName, string employeeNewName)
        {
            List<Employee> list = _employeeRepository.GetAll();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == employeeOldName)
                    {
                        list[i].Name = employeeNewName;
                        _employeeRepository.Update(list[i]);
                        return list[i];
                    }

                }
            }
            throw new NoEmployeeFoundException();
        }

        public Employee GetEmployeeById(int id)
        {
            var result = _employeeRepository.Get(id);
            if (result != null)
            {
                return result;
            }
            throw new NoEmployeeFoundException();
        }

        public Employee GetEmployeeByName(string employeeName)
        {
            List<Employee> list = _employeeRepository.GetAll();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == employeeName)
                    {
                        var result = _employeeRepository.Get(list[i].Id);
                        return result;
                    }
                }
            }
            throw new NoEmployeeFoundException();
        }

        public List<Employee> GetEmployeeList()
        {
            List<Employee> list = _employeeRepository.GetAll();
            if (list != null)
            {
                return list;
            }
            throw new NoEmployeeFoundException();
        }
    }
}
