using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;

namespace ShoppingDALTest
{
    public class CartRepositoryTest

    {
        IRepository<int, Cart> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            //Action
            var result = repository.Add(cart);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            //Action
            repository.Add(cart);
            //Assert
            cart = new Cart() { Id = 101 };
            //Action
            var result = repository.Add(cart);
            Assert.IsNull(result);
        }

        [Test]
        public void AddExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            var result = repository.Add(cart);
            cart = new Cart() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => repository.Add(cart));
            //Assert
            
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            repository.Add(cart);
            //Action
            var result = repository.Delete(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            repository.Add(cart);
            //Action
            var result = repository.Delete(100);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void DeleteExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            repository.Add(cart);
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => repository.Delete(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            repository.Add(cart);
            //Action
            var result = repository.GetByKey(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void GetFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            //Action
            var result = repository.GetByKey(100);
            //Assert
            Assert.AreNotEqual(101, result.Id);
        }

        [Test]
        public void GetExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => repository.Delete(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            repository.Add(cart);
            //Action
            var result = repository.Update(cart);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void UpdateFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };// No need to create
            cart.Id = 100;
            //Action
            var result = repository.Update(cart);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public void UpdateExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            cart.Id = 100;
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => repository.Update(cart));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }
    }
}