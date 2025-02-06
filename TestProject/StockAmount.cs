using NUnit.Framework;
using ECommerceApp;
using System;

namespace TestProject
{
    [TestFixture]
    public class StockAmount
    {
        [Test]
        public void StockAmount_ShouldBeSetCorrectly()
        {
            // Arrange: 
            Product product = new Product(100, "Test Product", 100.20, 10);

            // Act: 
            var actualStockAmount = product.StockAmount;

            // Assert: 
            Assert.That(actualStockAmount, Is.EqualTo(10));
        }

        [Test]
        public void StockAmount_ShouldThrowException_WhenLessThan5()
        {
            // Arrange: 
            TestDelegate action = () => new Product(100, "Test Product", 100.20, 4);

            // Act & Assert: 
            Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void StockAmount_ShouldThrowException_WhenGreaterThan500000()
        {
            // Arrange: 
            TestDelegate action = () => new Product(100, "Test Product", 100.20, 500001);

            // Act & Assert: 
            Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}
