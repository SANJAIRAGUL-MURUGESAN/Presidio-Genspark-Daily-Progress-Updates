using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CustomerExceptions;
using ShoppingModelLibrary.ProductExceptions;

namespace ShoppingBLTest
{
    public class ProductBLTest
    {
        IRepository<int, Product> repository;
        IProductService productService;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
            Product product = new Product() { Name = "Television", Id = 101 };
            repository.Add(product);
            productService = new ProductBL(repository);
        }

        [Test]
        public async Task DeleteProductSuccessTest()
        {
            var product = await productService.deleteProduct(101);
            Assert.AreEqual(101, product.Id);
        }

        [Test]
        public async Task DeleteProductFailTest()
        {
            var product = await productService.deleteProduct(102);
            Assert.AreNotEqual(101, product.Id);
        }

        [Test]
        public async Task DeleteProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await productService.deleteProduct(102));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetProductSuccessTest()
        {
            var product = await productService.GetProduct(101);
            Assert.AreEqual(101, product.Id);
        }

        [Test]
        public async Task GetProductFailTest()
        {
            var product = await productService.GetProduct(102);
            Assert.AreEqual(101, product.Id);
        }

        [Test]
        public async Task GetProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await productService.GetProduct(102));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateProductSuccessTest()
        {
            var cart = await productService.UpdateProductName(101, "TV");
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task UpdateProductFailTest()
        {
            var cart = await productService.UpdateProductName(102, "TV");
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task UpdateProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await productService.UpdateProductName(102,"TV"));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetAllProductSuccessTest()
        {
            var cart = await productService.GetAllProduct();
            Assert.GreaterOrEqual(1, cart.Count );
        }

        [Test]
        public async Task GetAllProductFailTest()
        {
            var cart = await productService.GetAllProduct();
            Assert.LessOrEqual(0, cart.Count);
        }

        [Test]
        public async Task GetAllProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(async() => await productService.GetAllProduct());
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }
    }
}