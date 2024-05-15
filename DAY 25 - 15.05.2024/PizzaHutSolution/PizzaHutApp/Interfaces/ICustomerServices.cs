using PizzaHutApp.Models;

namespace PizzaHutApp.Interfaces
{
    public interface ICustomerServices
    {
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> UpdateCustomerName(int key, string NewName);
        public Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
