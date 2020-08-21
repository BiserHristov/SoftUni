using System;
using System.Linq;
using NUnit.Framework;

namespace Store.Tests
{
    [TestFixture]
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Product_ValidDataShouldCreateValidProduct()
        {
            var product = new Product("a", 5, 20.5M);
            Assert.That("a",Is.EqualTo(product.Name));
            Assert.That(5, Is.EqualTo(product.Quantity));
            Assert.That(20.5, Is.EqualTo(product.Price));

        }
        [Test]
        public void SM_EmptyConstructorShouldCeateEmptyList()
        {
            var manager = new StoreManager();

            Assert.That(0, Is.EqualTo(manager.Products.Count));
            
        }

        [Test]
        public void Product_CountReturnCorrectResultWithEmptyCollection()
        {
            var manager = new StoreManager();

            Assert.That(0, Is.EqualTo(manager.Count));
           
        }

        [Test]
        public void Product_CountReturnCorrectResultWithNotEmptyCollection()
        {
            var manager = new StoreManager();

            var product = new Product("a", 5, 20.5M);

            manager.AddProduct(product);
            Assert.That(1, Is.EqualTo(manager.Count));

        }

        [Test]
        public void AddProduct_NullProductShouldThrow()
        {
            var manager = new StoreManager();

            Assert.Throws<ArgumentNullException>(() => manager.AddProduct(null));

        }

        [Test]
        public void AddProduct_ProductZeroQuantityShouldThrow()
        {
            var manager = new StoreManager();
            var product = new Product("a", 0, 20.5M);

            Assert.Throws<ArgumentException>(() => manager.AddProduct(product));

        }

        [Test]
        public void AddProduct_ProductLessThanZeroQuantityShouldThrow()
        {
            var manager = new StoreManager();
            var product = new Product("a", -6, 20.5M);

            Assert.Throws<ArgumentException>(() => manager.AddProduct(product));

        }

        [Test]
        public void AddProduct_ValidProductShouldBeAddedToCollection()
        {
            var manager = new StoreManager();
            var product = new Product("a", 5, 20.5M);
            manager.AddProduct(product);

            var searchedProduct =
                manager.Products.FirstOrDefault(p => p.Name == "a" && p.Quantity == 5 && product.Price == 20.5M);
            Assert.IsNotNull(searchedProduct);
            Assert.That("a", Is.EqualTo(searchedProduct.Name));
            Assert.That(5, Is.EqualTo(searchedProduct.Quantity));
            Assert.That(20.5, Is.EqualTo(searchedProduct.Price));
            Assert.That(1, Is.EqualTo(manager.Count));

        }

        [Test]
        public void BuyProduct_NotExistingProductShouldThrow()
        {
            var manager = new StoreManager();
            var product = new Product("a", 7, 20.5M);
            manager.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() => manager.BuyProduct("f", 7));

        }

        [Test]
        public void BuyProduct_NotEnoughProductQuantityShouldThrow()
        {
            var manager = new StoreManager();
            var product = new Product("a", 3, 20.5M);
            manager.AddProduct(product);

            Assert.Throws<ArgumentException>(() => manager.BuyProduct("a", 7));

        }

        [Test]
        public void BuyProduct_ValidProductShouldDecreaseProductQuantity()
        {
            var manager = new StoreManager();
            var product = new Product("a", 5, 20.5M);
            manager.AddProduct(product);
            manager.BuyProduct("a", 2);

            Product searchedProduct = manager.Products.FirstOrDefault(p => p.Name == "a");
            Assert.That(3, Is.EqualTo(searchedProduct.Quantity));


        }

        [Test]
        public void BuyProduct_ValidProductShouldReturnValidFinalPrice()
        {
            var manager = new StoreManager();
            var product = new Product("a", 5, 20.5M);
            manager.AddProduct(product);
            var finalPrice=manager.BuyProduct("a", 2);

           
            Assert.That(41, Is.EqualTo(finalPrice));

        }

        [Test]
        public void GetTheMostExpensiveProduct_ShouldReturnValidResult()
        {
            var manager = new StoreManager();
            var product = new Product("a", 5, 20.5M);
            var product2 = new Product("b", 6, 400M);
            var product3 = new Product("c", 9, 100M);


            manager.AddProduct(product);
            manager.AddProduct(product2);
            manager.AddProduct(product3);

            var mostExpensive = manager.GetTheMostExpensiveProduct();

            Assert.That(400, Is.EqualTo(mostExpensive.Price));




        }
    }
}