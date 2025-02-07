using NUnit.Framework;
using ECommerceApp;
using System;

namespace ECommerceApp.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product(100, "Test Product", 100.0, 50);
        }

        // Tests for Product Name
        [Test]
        public void ProdName_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ProdName, Is.EqualTo("Test Product"));
        }

        [Test]
        public void ProdName_ShouldThrowException_WhenEmptyString()
        {
            TestDelegate action = () => new Product(100, "", 100.0, 10);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void ProdName_ShouldThrowException_WhenExceedsMaxLength()
        {
            string longName = new string('A', 101);
            TestDelegate action = () => new Product(100, longName, 100.0, 10);
            Assert.Throws<ArgumentException>(action);
        }

        // Tests for Product ID
        [Test]
        public void ProdID_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ProdID, Is.EqualTo(100));
        }

        [Test]
        public void ProdID_ShouldThrowException_WhenLessThan5()
        {
            TestDelegate action = () => new Product(4, "Test Product", 100.0, 10);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void ProdID_ShouldThrowException_WhenGreaterThan50000()
        {
            TestDelegate action = () => new Product(50001, "Test Product", 100.0, 10);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        // Unit Tests for IncreaseStock()
        [Test]
        public void IncreaseStock_WithPositiveAmount_IncreasesStockCorrectly()
        {
            _product.IncreaseStock(10);
            Assert.That(_product.StockAmount, Is.EqualTo(60));
        }

        [Test]
        public void IncreaseStock_WithZeroAmount_StockUnchanged()
        {
            _product.IncreaseStock(0);
            Assert.That(_product.StockAmount, Is.EqualTo(50));
        }

        [Test]
        public void IncreaseStock_WithNegativeAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _product.IncreaseStock(-1));
        }

        // Unit Tests for DecreaseStock()
        [Test]
        public void DecreaseStock_WithPositiveAmount_DecreasesStockCorrectly()
        {
            _product.DecreaseStock(10);
            Assert.That(_product.StockAmount, Is.EqualTo(40));
        }

        [Test]
        public void DecreaseStock_WithZeroAmount_StockUnchanged()
        {
            _product.DecreaseStock(0);
            Assert.That(_product.StockAmount, Is.EqualTo(50));
        }

        [Test]
        public void DecreaseStock_MoreThanAvailable_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _product.DecreaseStock(60));
        }
    }
}
