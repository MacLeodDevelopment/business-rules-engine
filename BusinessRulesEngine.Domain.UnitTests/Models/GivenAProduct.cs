using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Models
{
    [TestFixture]
    public class GivenAProduct
    {
        [Test]
        public void ThenProductTypeIsSetFromTheConstructor()
        {
            var product = new Product("Expected");

            product.ProductType.Should().Be("Expected");
        }
    }
}