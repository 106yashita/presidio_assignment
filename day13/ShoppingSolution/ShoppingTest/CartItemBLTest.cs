using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTest
{
    public class CartItemBLTest
    {
        private CartItemBL _cartItemBL;
        private IRepository<int, CartItem> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new CartItemRepository();
            _cartItemBL = new CartItemBL(_repository);
        }

        [Test]
        public void AddCartItemSuccess()
        {
            // Arrange
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem item = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            );
            // Act
            var result = _cartItemBL.AddCartItem(item);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(item, result);
        }

        [Test]
        public void DeleteCartItemSuccess()
        {
            // Arrange
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem cartItem = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            ); 
            _cartItemBL.AddCartItem(cartItem);

            // Act
            var result = _cartItemBL.DeleteCartItem(cartItem.CartId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateCartItemSuccess()
        {
            // Arrange
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem cartItem = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            );
            _cartItemBL.AddCartItem(cartItem);

            // Modify the cart item
            cartItem.Quantity = 2;

            // Act
            var result = _cartItemBL.UpdateCartItem(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void GetCartItemByIdSuccess()
        {
            // Arrange
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem cartItem = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            ); 
            _cartItemBL.AddCartItem(cartItem);

            // Act
            var result = _cartItemBL.GetCartItemById(cartItem.CartId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void GetCartItemByIdException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => _cartItemBL.GetCartItemById(999));
        }

        [Test]
        public void UpdateCartItem_CartItemDoesNotExist_ExceptionThrown()
        {
            // Arrange
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem cartItem = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            );
            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => _cartItemBL.UpdateCartItem(cartItem));
        }

        [Test]
        public void DeleteCartItemException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => _cartItemBL.DeleteCartItem(999));
        }
    }
}
