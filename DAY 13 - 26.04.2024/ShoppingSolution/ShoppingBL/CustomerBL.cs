using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _CustomerRepository;
        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        [ExcludeFromCodeCoverage]
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _CustomerRepository.Add(customer);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var result = await _CustomerRepository.Delete(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoCartWithGivenIdException();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var result = await _CustomerRepository.GetByKey(id);
            return result;
            //if (result != null)
            //{
            //    return result;
            //}
            //throw new NoCartWithGivenIdException();
        }

        public async Task<Customer> UpdateCustomerName(int id,string Newname)
        {
            var result = await _CustomerRepository.GetByKey(id);
            result.Name = Newname;
            var result2 = await _CustomerRepository.Update(result);
            return result2;
            //if (result != null)
            //{
            //    result.Name = Newname;
            //    var result2 = _CustomerRepository.Update(result);
            //    return result;
            //}
            //throw new NoCartWithGivenIdException();
        }
    }
}
