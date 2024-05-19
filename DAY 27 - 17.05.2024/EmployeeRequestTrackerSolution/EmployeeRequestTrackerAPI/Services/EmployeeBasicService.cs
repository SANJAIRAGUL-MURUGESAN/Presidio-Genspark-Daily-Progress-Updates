using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeBasicService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        private readonly IRepository<int, User> _userRepo;

        public EmployeeBasicService(IRepository<int, Employee> reposiroty, IRepository<int, User> userRepo)
        {
            _repository = reposiroty;
            _userRepo = userRepo;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoSuchEmployeeException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
        public async Task<EnableUserReturnDTO> UpdateEmployeeStatus(EnableUserDTO EnableUserDTO)
        {
            var employee = await _repository.Get(EnableUserDTO.EmployeeId);
            if (employee == null)
                throw new NoSuchEmployeeException();
            User user = await _userRepo.Get(employee.Id);
            user.Status = EnableUserDTO.status;
            user = await _userRepo.Update(user);
            EnableUserReturnDTO userReturnDTO = new EnableUserReturnDTO();
            userReturnDTO.status = user.Status;
            userReturnDTO.Name = employee.Name;
            userReturnDTO.Role = employee.Role;
            userReturnDTO.Id = employee.Id;
            return userReturnDTO;
        }

    }
}
