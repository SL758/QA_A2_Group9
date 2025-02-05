using NUnit.Framework;
using ECommerceApp;
using System;

namespace ECommerceApp.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ProdName_ShouldBeSetCorrectly()
        {
            // Arrange: 
            Product product = new Product(100, "Test Product", 100.0, 10);

            // Act: 
            var actualProdName = product.ProdName;

            // Assert: 
            Assert.That(actualProdName, Is.EqualTo("Test Product"));
        }

        [Test]
        public void ProdName_ShouldThrowException_WhenEmptyString()
        {
            // Arrange: 
            TestDelegate action = () => new Product(100, "", 100.0, 10);

            // Act & Assert: 
            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ProdName_ShouldThrowException_WhenExceedsMaxLength()
        {
            // Arrange: 
            string longName = new string('A', 101);
            TestDelegate action = () => new Product(100, longName, 100.0, 10);

            // Act & Assert: 
            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }


    }
}
