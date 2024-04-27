using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTest
{
    public class CartRepoTest
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
            cartItems.Add( item );
            Cart cart = new Cart(
                id: 1, 
                customerId: 1, 
                customer: customer, 
                cartItems: cartItems 
            );
            var result = repository.Add(cart);

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void AddFailTest()
        {
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
            repository.Add(cart);
            Customer customer1 = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product1 = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem item1 = new CartItem(
                cartId: 1,
                productId: 1,
                product: product1,
                quantity: 3,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems1 = new List<CartItem>();
            cartItems1.Add(item1);
            Cart cart1 = new Cart(
                id: 1,
                customerId: 1,
                customer: customer1,
                cartItems: cartItems1
            );
            var exception = Assert.Throws<ItemPresentException>(() => repository.Add(cart1));
            //Assert
            Assert.AreEqual("Item already present", exception.Message);
        }

        [Test]
        public void GetAllSuccessTest()
        {
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
            repository.Add(cart);
            Customer customer1 = new Customer() { Id = 2, Age = 22, Phone = "345654" };
            Product product1 = new Product()
            {
                Id = 2,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem item1 = new CartItem(
                cartId: 2,
                productId: 2,
                product: product1,
                quantity: 3,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems1 = new List<CartItem>();
            cartItems1.Add(item1);
            Cart cart1 = new Cart(
                id: 2,
                customerId: 2,
                customer: customer1,
                cartItems: cartItems1
            );
            repository.Add(cart1);
            List<Cart> items = repository.GetAll().Result.ToList();

            //Assert
            Assert.AreEqual(2, items.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            List<Cart> items = repository.GetAll().Result.ToList();

            //Assert
            Assert.IsEmpty(items);
        }

        [Test]
        public void GetIdSuccessTest()
        {
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
            repository.Add(cart);
            var result = repository.GetByKey(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetIdFailTest()
        {
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
            repository.Add(cart);
            var result = repository.GetByKey(2);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteSuccessTest()
        {
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
            repository.Add(cart);
            var result = repository.Delete(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteFailTest()
        {
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
            repository.Add(cart);
            var result = repository.Delete(2);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void UpdateSuccessTest()
        {
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
            repository.Add(cart);
            Customer customer1 = new Customer() { Id = 1, Age = 12, Phone = "345654" };
            Product product1 = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem item1 = new CartItem(
                cartId: 1,
                productId: 1,
                product: product1,
                quantity: 3,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems1 = new List<CartItem>();
            cartItems.Add(item1);
            Cart cart1 = new Cart(
                id: 1,
                customerId: 1,
                customer: customer1,
                cartItems: cartItems
            );
            var result = repository.Update(cart1);
            Assert.AreEqual(12, result.Result.Customer.Age);
        }

        [Test]
        public void UpdateFailTest()
        {
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
            repository.Add(cart);
            Customer customer1 = new Customer() { Id = 1, Age = 22, Phone = "345654" };
            Product product1 = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem item1 = new CartItem(
                cartId: 1,
                productId: 1,
                product: product1,
                quantity: 3,
                price: 11,
                discount: 0
            );
            List<CartItem> cartItems1 = new List<CartItem>();
            cartItems1.Add(item1);
            Cart cart1 = new Cart(
                id: 2,
                customerId: 1,
                customer: customer1,
                cartItems: cartItems
            );
            var result = repository.Update(cart1);
            //Assert
            Assert.IsNull(result);
        }
    }
}
