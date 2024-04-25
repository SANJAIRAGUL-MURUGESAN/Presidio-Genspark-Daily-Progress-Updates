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
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(int id);
        Customer UpdateCustomerName(int id, string Newname);
        Customer DeleteCustomer(int id);
        
    }
}
