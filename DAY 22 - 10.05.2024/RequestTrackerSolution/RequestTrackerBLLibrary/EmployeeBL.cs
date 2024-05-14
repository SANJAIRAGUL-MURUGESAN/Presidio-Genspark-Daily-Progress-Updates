using RequestTrackerBLLibrary.RequestExceptions;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        private readonly IRepository<int, Employee> _repository2;
        public EmployeeBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _repository = repo;
            IRepository<int, Employee> repo2 = new EmployeeRequestRepository(new RequestTrackerContext());
            _repository2 = repo2;
        }
        public async Task<Employee> Login(Employee employee)
        {
            var emp = await _repository.Get(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                    return emp;
            }
            return null;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }

        public async Task<IList<Employee>> GetAllEmployees()
        {
            var result = await _repository2.GetAll();
            if (result != null)
            {
                return result;
            }
            throw new NoEmployeeFoundException();
        }

        public async Task<Employee> GetEmployeeByID(int key)
        {
            var result = await _repository.Get(key);
            if (result != null)
            {
                return result;
            }
            throw new NoEmployeeFoundException();
        }

        public async Task<Employee> GetRequestSolutionsByEmployeeID(int key)
        {
            var result = await _repository2.Get(key);
            if (result != null)
            {
                return result;
            }
            throw new NoEmployeeFoundException();
        }
    }
}
