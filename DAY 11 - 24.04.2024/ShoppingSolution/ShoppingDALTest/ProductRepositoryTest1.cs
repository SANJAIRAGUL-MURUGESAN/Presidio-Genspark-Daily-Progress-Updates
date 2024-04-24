using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CustomerExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class ProductRepositoryTest1
    {
        IRepository<int, Product> repository;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
        }
        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Name = "Sanjai" };
            //Action
            var result = repository.Add(product);
            //Assert
            Assert.AreEqual("Sanjai", result.Name);
        }
        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Product product = new Product() { Name = "Sanjai" };
            //Action
            var result = repository.Add(product);
            product = new Product() { Name = "Sanjai" };
            Assert.IsNull(product);
        }
        [Test]
        public void AddExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = repository.Add(product);
            product = new Product() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Add(product));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }
        [Test]
        public void DeleteSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            var result = repository.Add(product);
            //Action
            var result2 = repository.Delete(101);
            //Assert
            Assert.AreEqual(101, result2.Id);
        }
        [Test]
        public void DeleteFailTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            var result = repository.Add(product);
            //Action
            var result2 = repository.Delete(102);
            //Assert
            Assert.AreEqual(101, result2.Id);
        }

        [Test]
        public void DeleteExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = repository.Add(product);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Delete(102));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            //Action
            var result = repository.Update(product);
            //Assert
            Assert.AreEqual(1, result.Id);
        }
        [Test]

        public void UpdateExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = repository.Add(product);
            product.Id = 102;
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Update(product));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateFailTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            product.Id = 102;
            //Action
            var result = repository.Update(product);
            //Assert
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public void GetSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            //Action
            var result = repository.GetByKey(101);
            //Assert
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public void GetFailTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            //Action
            var result = repository.GetByKey(102);
            //Assert
            Assert.AreNotEqual(1, result.Id);
        }

        [Test]
        public void GetExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = repository.Add(product);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => repository.GetByKey(102));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

    }
}
