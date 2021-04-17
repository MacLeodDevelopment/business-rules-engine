﻿using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules
{
    [TestFixture]
    public class GivenAGeneratePackingSlipForPhysicalProductWhenIsMatchIsInvoked
    {
        private GeneratePackingSlipForPhysicalProduct _generatePackingSlipForPhysicalProduct;
        private Order _orderWithPhysicalProduct;
        private Order _orderWithNonPhysicalProduct;
        
        [SetUp]
        public void Setup()
        {
            _orderWithPhysicalProduct = new Order();
            _orderWithPhysicalProduct.SetProduct(new Product(new ProductConfig {Type = "Physical"}));

            _orderWithNonPhysicalProduct = new Order();
            _orderWithNonPhysicalProduct.SetProduct(new Product(new ProductConfig {Type = "Anything Else"}));

            _generatePackingSlipForPhysicalProduct = new GeneratePackingSlipForPhysicalProduct();
        }

        [Test]
        public void AndTheSuppliedProductIsPhysical_ThenTrueIsReturned()
        {
            var actual = _generatePackingSlipForPhysicalProduct.IsMatch(_orderWithPhysicalProduct);

            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsNotPhysical_ThenFalseIsReturned()
        {
            var actual = _generatePackingSlipForPhysicalProduct.IsMatch(_orderWithNonPhysicalProduct);
            actual.Should().BeFalse();
        }

        [Test]
        public void WithAnInvalidOrder_ThenFalseIsReturned()
        {
            var actual = _generatePackingSlipForPhysicalProduct.IsMatch(null);
            actual.Should().BeFalse();
        }
        
        [Test]
        public void WithAnInvalidProduct_ThenFalseIsReturned()
        {
            var actual = _generatePackingSlipForPhysicalProduct.IsMatch(new Order());
            actual.Should().BeFalse();
        }
    }
}