using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;
using ShoppingModelLibrary.CustomerExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CustomerBLTest
    {
        IRepository<int, Customer> repository;
        ICustomerService customerService;
        public void Setup()
        {
            repository = new CustomerRepository();
            Customer customer = new Customer() { Name = "Sanjai" };
            repository.Add(customer);
            customerService = new CustomerBL(repository);
        }

        [Test]
        public void DeleteCustomerSuccessTest()
        {
            var cart = customerService.DeleteCustomer(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void DeleteCustomerFailTest()
        {
            var cart = customerService.DeleteCustomer(101);
            Assert.AreNotEqual(102, cart.Id);
        }

        [Test]
        public void DeleteCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerService.DeleteCustomer(102));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetCustomerSuccessTest()
        {
            var cart = customerService.GetCustomer(101);
            Assert.AreEqual(101, cart.Id);
        }
        [Test]
        public void GetCustomerFailTest()
        {
            var cart = customerService.GetCustomer(102);
            Assert.AreNotEqual(101, cart.Id);
        }

        [Test]
        public void GetCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerService.GetCustomer(102));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateCustomerSuccessTest()
        {
            var cart = customerService.UpdateCustomerName(101,"Sanjai Ragul");
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void UpdateCustomerFailTest()
        {
            var cart = customerService.UpdateCustomerName(102, "Sanjai Ragul");
            Assert.AreNotEqual(101, cart.Id);
        }
        [Test]
        public void UpdateCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerService.UpdateCustomerName(102, "Sanjai Ragul"));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
    }
}
