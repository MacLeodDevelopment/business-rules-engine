using System;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Models
{
    [TestFixture]
    public class GivenAProduct
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product(new ProductConfig
            {
                Name = "Expected Name",
                Type = "Expected Type",
                SubType = "Expected SubType"
            });
        }

        [Test]
        public void ThenNameIsSetFromTheConstructor()
        {
            _product.Name.Should().Be("Expected Name");
        }
        
        [Test]
        public void ThenProductTypeIsSetFromTheConstructor()
        {
            _product.ProductType.Should().Be("Expected Type");
        }
        
        [Test]
        public void ThenProductSubTypeIsSetFromTheConstructor()
        {
            _product.ProductSubType.Should().Be("Expected SubType");
        }
    }
}