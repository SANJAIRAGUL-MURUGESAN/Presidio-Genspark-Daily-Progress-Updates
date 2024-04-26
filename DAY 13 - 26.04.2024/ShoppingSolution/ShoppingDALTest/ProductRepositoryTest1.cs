using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CustomerExceptions;
using ShoppingModelLibrary.ProductExceptions;
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
        public async Task AddSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Name = "Sanjai" };
            //Action
            var result = await repository.Add(product);
            //Assert
            Assert.AreEqual("Sanjai", result.Name);
        }
        [Test]
        public async Task AddFailTest()
        {
            //Arrange 
            Product product = new Product() { Name = "Sanjai" };
            //Action
            var result = await repository.Add(product);
            product = new Product() { Name = "Sanjai" };
            Assert.IsNull(product);
        }
        [Test]
        public async Task AddExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = await repository.Add(product);
            product = new Product() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await repository.Add(product));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }
        [Test]
        public async Task DeleteSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            var result = await repository.Add(product);
            //Action
            var result2 = await repository.Delete(101);
            //Assert
            Assert.AreEqual(101, result2.Id);
        }
        [Test]
        public async Task DeleteFailTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            var result = await repository.Add(product);
            //Action
            var result2 = await repository.Delete(102);
            //Assert
            Assert.AreEqual(101, result2.Id);
        }

        [Test]
        public async Task DeleteExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = await repository.Add(product);
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await repository.Delete(102));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            await repository.Add(product);
            //Action
            var result = await repository.Update(product);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]

        public async Task UpdateExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = await repository.Add(product);
            Product P2 = new Product();
            P2.Id = 102;
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await repository.Update(P2));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateFailTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            await repository.Add(product);
            product.Id = 102;
            //Action
            var result = await repository.Update(product);
            //Assert
            Assert.AreNotEqual(101, result.Id);
        }
        [Test]
        public async Task GetSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            await repository.Add(product);
            //Action
            var result = await repository.GetByKey(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task GetFailTest()
        {
            //Arrange 
            Product product = new Product() { Id = 101, Name = "Sanjai" };
            await repository.Add(product);
            //Action
            var result = await repository.GetByKey(102);
            //Assert
            Assert.AreNotEqual(101, result.Id);
        }

        [Test]
        public async Task GetExceptionTest()
        {
            Product product = new Product() { Id = 101 };
            var result = await repository.Add(product);
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await repository.GetByKey(102));
            //Assert

            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

    }
}
