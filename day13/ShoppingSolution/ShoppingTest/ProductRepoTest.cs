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
    public class ProductRepoTest
    {
        IRepository<int, Product> repository;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            Product product = new Product() { Id = 1 , Name="book", Image="gfd", Price=22, QuantityInHand=2};
            var result = repository.Add(product);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            Product product1 = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            var exception = Assert.Throws<ItemPresentException>(() => repository.Add(product1));
            //Assert
            Assert.AreEqual("Item already present", exception.Message);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            Product product1 = new Product() { Id = 2, Name = "copy", Image = "gfd", Price = 12, QuantityInHand = 2 };
            repository.Add(product1);
            List<Product> products = repository.GetAll().Result.ToList();

            //Assert
            Assert.AreEqual(2, products.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            List<Product> products = repository.GetAll().Result.ToList();

            //Assert
            Assert.IsEmpty(products);
        }

        [Test]
        public void GetIdSuccessTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            var result = repository.GetByKey(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetIdFailTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            var result= repository.GetByKey(2);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            var result = repository.Delete(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteFailTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            var result = repository.Delete(2);
            //Assert
            Assert.IsNull(result);
        }
        [Test]
        public void UpdateSuccessTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            Product product1 = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 32, QuantityInHand = 4 };
            var result = repository.Update(product1);
            Assert.AreEqual(32, result.Result.Price);
        }

        [Test]
        public void UpdateFailTest()
        {
            Product product = new Product() { Id = 1, Name = "book", Image = "gfd", Price = 22, QuantityInHand = 2 };
            repository.Add(product);
            Product product1 = new Product() { Id = 2, Name = "book", Image = "gfd", Price = 32, QuantityInHand = 4 };

            var result = repository.Update(product1);
            //Assert
            Assert.IsNull(result);
        }
    }
}
