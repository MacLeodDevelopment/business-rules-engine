using BusinessRulesEngine.Domain.Models;
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
            _orderWithPhysicalProduct = new Order
            {
                Product = new Product("Physical")
            };

            _orderWithNonPhysicalProduct = new Order
            {
                Product = new Product("Anything Else")
            };

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
            var actual = _generatePackingSlipForPhysicalProduct.IsMatch(new Order {Product = new Product(null)});
            actual.Should().BeFalse();
        }
    }
}