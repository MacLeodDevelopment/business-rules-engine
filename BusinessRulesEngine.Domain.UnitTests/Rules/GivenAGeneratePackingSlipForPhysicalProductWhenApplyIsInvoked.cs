using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules
{
    [TestFixture]
    public class GivenAGeneratePackingSlipForPhysicalProductWhenApplyIsInvoked
    {
        private GeneratePackingSlipForPhysicalProduct _generatePackingSlipForPhysicalProduct;
        private Mock<Order> _mockOrder;

        [SetUp]
        public void Setup()
        {
            _mockOrder = new Mock<Order>();
            _mockOrder.Setup(m => m.SetPackingSlip("Shipping"));

            _generatePackingSlipForPhysicalProduct = new GeneratePackingSlipForPhysicalProduct();
        }

        [Test]
        public void ThenANewPackingSlipIsGeneratedAndAddedToTheOrder()
        {
            _generatePackingSlipForPhysicalProduct.Apply(_mockOrder.Object);

            _mockOrder.Verify(m => m.SetPackingSlip("Shipping"), Times.Once);
        }
    }
}