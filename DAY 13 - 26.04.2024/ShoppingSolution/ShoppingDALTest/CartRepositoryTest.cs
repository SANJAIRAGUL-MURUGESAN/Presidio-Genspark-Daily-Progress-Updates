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
        public async Task AddSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            //Action
            var result = await repository.Add(cart);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task AddFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            //Action
            await repository.Add(cart);
            //Assert
            cart = new Cart() { Id = 101 };
            //Action
            var result = await repository.Add(cart);
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            var result = await repository.Add(cart);
            cart = new Cart() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async() => await repository.Add(cart));
            //Assert
            
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task DeleteSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            await repository.Add(cart);
            //Action
            var result = await repository.Delete(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task DeleteFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            await repository.Add(cart);
            //Action
            var result = await repository.Delete(100);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task DeleteExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            await repository.Add(cart);
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async() => await repository.Delete(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            await repository.Add(cart);
            //Action
            var result = await repository.GetByKey(101);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task GetFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            //Action
            var result = await repository.GetByKey(100);
            //Assert
            Assert.AreNotEqual(101, result.Id);
        }

        [Test]
        public async Task GetExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async() => await repository.Delete(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateSuccessTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };
            await repository.Add(cart);
            //Action
            var result = await repository.Update(cart);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task UpdateFailTest()
        {
            //Arrange 
            Cart cart = new Cart() { Id = 101 };// No need to create
            cart.Id = 100;
            //Action
            var result = await repository.Update(cart);
            //Assert
            Assert.AreEqual(101, result.Id);
        }

        [Test]
        public async Task UpdateExceptionTest()
        {
            Cart cart = new Cart() { Id = 101 };
            cart.Id = 100;
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async() => await repository.Update(cart));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }
    }
}