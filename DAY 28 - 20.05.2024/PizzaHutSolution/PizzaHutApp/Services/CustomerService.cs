using PizzaHutApp.Exceptions;
using PizzaHutApp.Interfaces;
using PizzaHutApp.Models;

namespace PizzaHutApp.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly IRepository<int, Customer> _repository;

        public CustomerService(IRepository<int, Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _repository.Add(customer);
            if(result != null)
            {
                return result;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _repository.Get();
            if (customers.Count() == 0)
                throw new NoSuchCustomerFoundException();
            return customers;
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerName(int key, string NewName)
        {
            throw new NotImplementedException();
        }
    }
}
