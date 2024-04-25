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
        public void DeleteCartSuccessTest()
        {
            var cart = cartService.DeleteCart(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void DeleteCartFailTest()
        {
            var cart = cartService.DeleteCart(101);
            Assert.AreNotEqual(101, cart.Id);
        }

        [Test]
        public void DeleteCartExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.DeleteCart(2));
            //Asserts
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetCartSuccessTest()
        {
            var cart = cartService.GetCart(101);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void GetCartFailTest()
        {
            var cart = cartService.GetCart(102);
            Assert.AreNotEqual(101, cart.Id);
        }

        [Test]
        public void GetCartExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.GetCart(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddCartItemSuccessTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 101;
            Cart cart = cartService.AddCartItem(cartitem);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void AddCartItemFailTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 102;
            var cart = cartService.AddCartItem(cartitem);
            Assert.AreEqual(101, cart.Id);
        }

        [Test]
        public void AddCartExceptionTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 102;
            cartitem.Price = 3000;
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.AddCartItem(cartitem));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }
        [Test]
        public void CustomerPurchaseSuccessTest()
        {
            double price = cartService.CustomerPurchase(101);
            Assert.AreEqual(0,price);
        }

        [Test]
        public void CustomerPurchaseFailTest()
        {
            CartItem cartitem = new CartItem();
            cartitem.CartId = 101;
            cartitem.Price = 8000;
            cartService.AddCartItem(cartitem);
            var cart = cartService.CustomerPurchase(102);
            Assert.AreEqual(8550, cart);
        }
        [Test]
        public void CustomerPurchaseExceptionTest()
        {   
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.CustomerPurchase(102));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

    }
}
