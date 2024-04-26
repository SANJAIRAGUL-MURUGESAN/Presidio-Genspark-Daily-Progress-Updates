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
        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
            Customer customer = new Customer() { Name = "Sanjai", Id = 101 };
            repository.Add(customer);
            customerService = new CustomerBL(repository);
        }

        [Test]
        public async Task DeleteCustomerSuccessTest()
        {
            var cart = await customerService.DeleteCustomer(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task DeleteCustomerFailTest()
        {
            var cart = await customerService.DeleteCustomer(101);
            Assert.AreNotEqual(102, cart.Id);
        }

        [Test]
        public async Task DeleteCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => await customerService.DeleteCustomer(102));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetCustomerSuccessTest()
        {
            var cart = await customerService.GetCustomer(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task GetCustomerFailTest()
        {
            var cart = await customerService.GetCustomer(102);
            Assert.AreNotEqual(101, cart.Id);
        }

        [Test]
        public async Task GetCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => await customerService.GetCustomer(102));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateCustomerSuccessTest()
        {
            var cart = await customerService.UpdateCustomerName(101,"Sanjai Ragul");
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task UpdateCustomerFailTest()
        {
            var cart = await customerService.UpdateCustomerName(102, "Sanjai Ragul");
            Assert.AreNotEqual(101, cart.Id);
        }
        [Test]
        public async Task UpdateCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => customerService.UpdateCustomerName(102, "Sanjai Ragul"));
            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
    }
}
