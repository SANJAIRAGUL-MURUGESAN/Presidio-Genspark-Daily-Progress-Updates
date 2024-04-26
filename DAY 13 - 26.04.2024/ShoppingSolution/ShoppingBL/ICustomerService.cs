using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<Customer> UpdateCustomerName(int id, string Newname);
        Task<Customer> DeleteCustomer(int id);
        
    }
}
