using System;
using NUnit.Framework;
using ECommerceApp;

namespace ECommerceApp.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ProdName_ShouldBeSetCorrectly()
        {
            // Arrange: 创建一个 Product 对象，设置 ProdName 为 "Test Product"
            Product product = new Product(100, "Test Product", 100.0, 10);

            // Act: 获取 ProdName
            var actualProdName = product.ProdName;

            // Assert: 验证 ProdName 是否等于 "Test Product"
            Assert.That(actualProdName, Is.EqualTo("Test Product"));
        }
    }
}
