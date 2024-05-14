using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        public Task<Employee> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
        public Task<IList<Employee>> GetAllEmployees();

        public Task<Employee> GetEmployeeByID(int key);
        public Task<Employee> GetRequestSolutionsByEmployeeID(int key);
    }
}
