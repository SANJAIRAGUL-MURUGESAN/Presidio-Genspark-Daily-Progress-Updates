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
        public void AddSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Name = "Sanjai" };
            //Action
            var result = repository.Add(customer);
            //Assert
            Assert.AreEqual("Sanjai", result.Name);
        }
        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Name = "Sanjai" };
            //Action
            var result = repository.Add(customer);
            Customer customer2 = new Customer() { Name = "Sanjai" };
            var result2 = repository.Add(customer2);
            Assert.IsNull(result2);
        }
        [Test]

        public void AddExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            var result = repository.Add(customer);
            customer = new Customer() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Add(customer));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            //Action
            var result = repository.Delete(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public void DeleteFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            //Action
            var result = repository.Delete(102);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void DeleteExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            var result = repository.Add(customer);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Delete(102));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            //Action
            var result = repository.Update(customer);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public void UpdateFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 101, Name = "Sanjai" };
            customer.Id = 102;
            //Action
            var result = repository.Update(customer);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public void UpdateExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            customer.Id = 102;
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Update(customer));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        public void GetSuccessTest()
        {
            //Arrange 
            Customer cart = new Customer() { Id = 101 };
            //Action
            var result = repository.GetByKey(101);
            //Assert
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public void GetFailTest()
        {
            //Arrange 
            Customer cart = new Customer() { Id = 101 };
            //Action
            var result = repository.GetByKey(102);
            //Assert
            Assert.AreNotEqual(1, result.Id);
        }
        public void getExceptionTest()
        {
            Customer customer = new Customer() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.GetByKey(102));
            //Assert

            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
    }
}
