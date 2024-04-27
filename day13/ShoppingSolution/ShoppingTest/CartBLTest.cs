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
    public class CartBLTest
    {
        private CartBL _cartBL;
        private IRepository<int, Cart> _repository;
        private IProductService _services;

        [SetUp]
        public void Setup()
        {
            _repository = new CartRepository();
            _services = new ProductBL();

            _cartBL = new CartBL(_repository, _services);
        }

        [Test]
        public void AddCartSuccess()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
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
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            // Act
            var result = _cartBL.AddCart(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void UpdateCartSuccess()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
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
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _repository.Add(cart);

            // Act
            var result = _cartBL.UpdateCart(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void UpdateCartException()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
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
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartBL.UpdateCart(cart));
        }

        [Test]
        public void GetCartByIdSuccess()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
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
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _repository.Add(cart);

            // Act
            var result = _cartBL.GetCartById(cart.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetCartByIdException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartBL.GetCartById(999));
        }

        [Test]
        public void DeleteCart_Success()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
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
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _repository.Add(cart);

            // Act
            var result = _cartBL.DeleteCart(cart.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteCartException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartBL.DeleteCart(999));
        }

        [Test]
        public void IsDiscountEligibleSuccess()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };
            _services.AddProduct(product);

            CartItem item = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _cartBL.AddCart(cart);
            // Act
            var result = _cartBL.IsDiscountEligible(cart);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CalculateShippingChargeSuccess()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };
            _services.AddProduct(product);

            CartItem item = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 3,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _cartBL.AddCart(cart);
            // Act
            var result = _cartBL.CalculateShippingCharge(cart);

            // Assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void CalculateShippingCharge()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 220,
                QuantityInHand = 2
            };
            _services.AddProduct(product);
            CartItem item = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 5,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _cartBL.AddCart(cart);
            // Act
            var result = _cartBL.CalculateShippingCharge(cart);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ValidateMaxQuantityInCartSuccess()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };
            _services.AddProduct(product);
            CartItem item = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 6,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );

            // Act
            var result = _cartBL.ValidateMaxQuantityInCart(cart);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateMaxQuantityInCartFailure()
        {
            // Arrange
            Customer customer = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };
            _services.AddProduct(product);
            CartItem item = new CartItem(
                cartId: 1,
                productId: 1,
                product: product,
                quantity: 1,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(item);
            Cart cart = new Cart(
                id: 1,
                customerId: 1,
                customer: customer,
                cartItems: cartItems
            );
            _cartBL.AddCart(cart);
            // Act
            var result = _cartBL.ValidateMaxQuantityInCart(cart);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
