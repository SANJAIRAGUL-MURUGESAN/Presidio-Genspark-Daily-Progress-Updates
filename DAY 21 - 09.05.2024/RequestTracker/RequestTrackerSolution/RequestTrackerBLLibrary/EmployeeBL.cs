using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<bool> Login(Employee employee)
        {
            var emp = await _repository.Get(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                    return true;
            }
            return false;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }
    }
}
