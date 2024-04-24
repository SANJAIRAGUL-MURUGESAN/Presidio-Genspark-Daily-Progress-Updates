using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;
using System;
using System.Collections.Generic;
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
        public Customer AddCustomer(Customer customer)
        {
            var result = _CustomerRepository.Add(customer);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Customer DeleteCustomer(int id)
        {
            var result = _CustomerRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Customer GetCustomer(int id)
        {
            var result = _CustomerRepository.GetByKey(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Customer UpdateCustomerName(int id,string Newname)
        {
            var result = _CustomerRepository.GetByKey(id);
            if (result != null)
            {
                result.Name = Newname;
                var result2 = _CustomerRepository.Update(result);
                return result;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
