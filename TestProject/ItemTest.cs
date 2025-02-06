using NUnit.Framework;
using ECommerceApp;
using System;

namespace TestProject
{
    [TestFixture]
    public class ItemTest
    {
        [Test]
        public void ItemPrice_ShouldBeSetCorrectly()
        {
            // Arrange: 
            Product product = new Product(100, "Test Product", 100.20, 10);

            // Act: 
            var actualItemPrice = product.ItemPrice;

            // Assert: 
            Assert.That(actualItemPrice, Is.EqualTo(100.20));
        }
        [Test]
        public void ItemPrice_ShouldThrowException_WhenLessThan5()
        {
            // Arrange: 
            TestDelegate action = () => new Product(100, "Test Product", 4.99, 10);

            // Act & Assert: 
            Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void ItemPrice_ShouldThrowException_WhenGreaterThan5000()
        {
            // Arrange: 
            TestDelegate action = () => new Product(100, "Test Product", 5000.01, 10);

            // Act & Assert: 
            Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}
