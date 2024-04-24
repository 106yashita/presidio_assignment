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
    public class CartItemRepoTest
    {
        IRepository<int, CartItem> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartItemRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
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
            var result = repository.Add(item);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {
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
            repository.Add(item);
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
            var exception = Assert.Throws<ItemPresentException>(() => repository.Add(item1));
            //Assert
            Assert.AreEqual("Item already present", exception.Message);
        }

        [Test]
        public void GetAllSuccessTest()
        {
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
            repository.Add(item);
            Product product1 = new Product()
            {
                Id = 1,
                Name = "book",
                Image = "gfd",
                Price = 22,
                QuantityInHand = 2
            };

            CartItem item1 = new CartItem(
                cartId: 2,
                productId: 1,
                product: product1,
                quantity: 4,
                price: 11,
                discount: 10
            );
            repository.Add(item1);
            List<CartItem> items = repository.GetAll().ToList();

            //Assert
            Assert.AreEqual(2, items.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            List<CartItem> items = repository.GetAll().ToList();

            //Assert
            Assert.IsEmpty(items);
        }

        [Test]
        public void GetIdSuccessTest()
        {
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
            repository.Add(item);
            var result = repository.GetByKey(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetIdFailTest()
        {
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
            repository.Add(item);
            var result = repository.GetByKey(2);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteSuccessTest()
        {
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
            repository.Add(item);
            var result = repository.Delete(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteFailTest()
        {
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
            repository.Add(item);
            var result = repository.Delete(2);
            //Assert
            Assert.IsNull(result);
        }
        [Test]
        public void UpdateSuccessTest()
        {
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
            repository.Add(item);
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
                price: 21,
                discount: 0
            );
            var result = repository.Update(item1);
            Assert.AreEqual(21, result.Price);
        }

        [Test]
        public void UpdateFailTest()
        {
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
            repository.Add(item);
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
                productId: 1,
                product: product1,
                quantity: 3,
                price: 11,
                discount: 0
            );
            var result = repository.Update(item1);
            //Assert
            Assert.IsNull(result);
        }
    }
}
