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
            //Assert
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
            var cart = cartService.AddCartItem(cartitem);
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
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.AddCartItem(cartitem));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }
        [Test]
        public void CustomerPurchaseSuccessTest()
        {
            var cart = cartService.CustomerPurchase(new Cart { Id = 101});
            Assert.AreEqual(1000,cart);
        }
        [Test]
        public void CustomerPurchaseFailTest()
        {
            var cart = cartService.CustomerPurchase(new Cart { Id = 102 });
            Assert.AreEqual(1000, cart);
        }
        [Test]
        public void CustomerPurchaseExceptionTest()
        {   
            //Action
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartService.CustomerPurchase(new Cart { Id = 102 }));
            //Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

    }
}
