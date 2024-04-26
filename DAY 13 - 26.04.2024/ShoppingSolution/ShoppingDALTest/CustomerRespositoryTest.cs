using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;
using ShoppingModelLibrary.CustomerExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CustomerRespositoryTest
    {
        IRepository<int, Customer> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
        }
        [Test]
        public async Task AddSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Name = "Sanjai" };
            //Action
            var result = await repository.Add(customer);
            //Assert
            Assert.AreEqual("Sanjai", result.Name);
        }
        [Test]
        public async Task AddFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Name = "Sanjai" };
            //Action
            var result = await repository.Add(customer);
            Customer customer2 = new Customer() { Name = "Sanjai" };
            var result2 = await repository.Add(customer2);
            Assert.IsNull(result2);
        }
        [Test]

        public async Task AddExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            var result = await repository.Add(customer);
            customer = new Customer() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => await repository.Add(customer));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task DeleteSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            await repository.Add(customer);
            //Action
            var result = await repository.Delete(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task DeleteFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            await repository.Add(customer);
            //Action
            var result = await repository.Delete(102);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task DeleteExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            var result = await repository.Add(customer);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => await repository.Delete(102));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            await repository.Add(customer);
            //Action
            var result = await repository.Update(customer);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task UpdateFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            customer.Id = 102;
            //Action
            var result = await repository.Update(customer);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task UpdateExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            customer.Id = 102;
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => await repository.Update(customer));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public async Task GetSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101 };
            await repository.Add(customer);
            //Action
            var result = await repository.GetByKey(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task GetFailTest()
        {
            //Arrange 
            Customer cart = new Customer() { Id = 101 };
            //Action
            var result = await repository.GetByKey(102);
            //Assert
            Assert.AreNotEqual(1, result.Id);
        }

        [Test]
        public async Task getExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(async() => await repository.GetByKey(102));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
    }
}
