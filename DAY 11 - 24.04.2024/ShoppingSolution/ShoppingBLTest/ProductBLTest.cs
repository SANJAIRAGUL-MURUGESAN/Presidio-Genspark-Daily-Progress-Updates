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
        public void DeleteProductSuccessTest()
        {
            var product = productService.deleteProduct(101);
            Assert.AreEqual(101, product.Id);
        }

        [Test]
        public void DeleteProductFailTest()
        {
            var product = productService.deleteProduct(102);
            Assert.AreNotEqual(101, product.Id);
        }

        [Test]
        public void DeleteProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(() => productService.deleteProduct(102));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetProductSuccessTest()
        {
            var product = productService.GetProduct(101);
            Assert.AreEqual(101, product.Id);
        }

        [Test]
        public void GetProductFailTest()
        {
            var product = productService.GetProduct(102);
            Assert.AreEqual(101, product.Id);
        }

        [Test]
        public void GetProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(() => productService.GetProduct(102));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateProductSuccessTest()
        {
            var cart = productService.UpdateProductName(101, "TV");
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void UpdateProductFailTest()
        {
            var cart = productService.UpdateProductName(102, "TV");
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void UpdateProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(() => productService.UpdateProductName(102,"TV"));
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllProductSuccessTest()
        {
            var cart = productService.GetAllProduct();
            Assert.GreaterOrEqual(0, cart.Count );
        }

        [Test]
        public void GetAllProductFailTest()
        {
            var cart = productService.GetAllProduct();
            Assert.LessOrEqual(0, cart.Count);
        }

        [Test]
        public void GetAllProductExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoProductWithGivenIDException>(() => productService.GetAllProduct());
            //Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }
    }
}