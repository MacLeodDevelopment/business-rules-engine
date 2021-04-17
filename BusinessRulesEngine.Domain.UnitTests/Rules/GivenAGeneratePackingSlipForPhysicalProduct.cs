using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules
{
    [TestFixture]
    public class GivenAGeneratePackingSlipForPhysicalProduct
    {
        private GeneratePackingSlipForPhysicalProduct _generatePackingSlipForPhysicalProduct;
        private Order _orderWithPhysicalProduct;

        [SetUp]
        public void Setup()
        {
            _orderWithPhysicalProduct = new Order();

            _generatePackingSlipForPhysicalProduct = new GeneratePackingSlipForPhysicalProduct();
        }

        public void WhenIsMatchIsInvoked_AndTheSuppliedProductIsPhysical_ThenTrueIsReturned()
        {
            var actual = _generatePackingSlipForPhysicalProduct.IsMatch(_orderWithPhysicalProduct);

            actual.Should().BeTrue();
        }
    }

    public class GeneratePackingSlipForPhysicalProduct : IRule
    {
        public bool IsMatch(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void Apply(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}