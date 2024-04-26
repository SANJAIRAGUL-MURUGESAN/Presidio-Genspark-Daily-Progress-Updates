using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.CartException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CartBLTest
    {
        IRepository<int, Cart> repository;
        ICartService cartService;
        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
            Cart cart = new Cart() { Id = 101 };
            repository.Add(cart);
            cartService = new CartBL(repository);
        }

        [Test]
        public async Task DeleteCartSuccessTest()
        {
            var cart = await cartService.DeleteCart(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task DeleteCartFailTest()
        {
            var cart = await cartService.DeleteCart(101);
            Assert.AreNotEqual(101, cart.Id);
        }

        [Test]
        public async Task DeleteCartExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.DeleteCart(2));
            //Asserts
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetCartSuccessTest()
        {
            var cart = await cartService.GetCart(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task GetCartFailTest()
        {
            var cart = await cartService.GetCart(102);
            Assert.AreNotEqual(101, cart.Id);
        }

        [Test]
        public async Task GetCartExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async () => await cartService.GetCart(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task AddCartItemSuccessTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 101;
            Cart cart = await cartService.AddCartItem(cartitem);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task AddCartItemFailTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 102;
            var cart = await cartService.AddCartItem(cartitem);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public async Task AddCartExceptionTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 102;
            cartitem.Price = 3000;
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async() => cartService.AddCartItem(cartitem));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }
        [Test]
        public async Task CustomerPurchaseSuccessTest()
        {
            double price = await cartService.CustomerPurchase(101);
            Assert.AreEqual(0,price);
        }

        [Test]
        public async Task CustomerPurchaseFailTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 101;
            cartitem.Price = 8000;
            await cartService.AddCartItem(cartitem);
            var cart = await cartService.CustomerPurchase(102);
            Assert.AreEqual(8550, cart);
        }
        [Test]
        public async Task CustomerPurchaseExceptionTest()
        {   
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(async() => await cartService.CustomerPurchase(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

    }
}
