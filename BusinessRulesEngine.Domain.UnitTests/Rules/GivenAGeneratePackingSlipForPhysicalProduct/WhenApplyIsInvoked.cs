using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAGeneratePackingSlipForPhysicalProduct
{
    /// <remarks>
    /// Some of the tests in here are more like integration tests.
    /// As the return type is void, we are reliant on some of the behaviour
    /// of PackingSlip to test the Apply method fully. Our other option
    /// is anemic (sic) domain models which some argue is an anti-pattern.
    /// </remarks>
    [TestFixture]
    public class WhenApplyIsInvoked : CommonApplyTestsSetupBase
    {
        private GeneratePackingSlipForPhysicalProduct _generatePackingSlipForPhysicalProduct;
        
        [SetUp]
        public new void Setup()
        {
            ExpectedPackingSlip = new PackingSlip("Shipping");
            ExpectedPackingSlip.AddProduct($"{ExpectedProduct.Name} ({ExpectedProduct.ProductSubType})");

            _generatePackingSlipForPhysicalProduct = new GeneratePackingSlipForPhysicalProduct(MockServiceBus.Object);
        }

        [Test]
        public void ThenANewPackingSlipIsGeneratedAndAddedToTheOrder()
        {
            _generatePackingSlipForPhysicalProduct.Apply(MockOrder.Object);

            MockOrder.Verify(m => m.SetPackingSlip(It.Is<PackingSlip>(ps => PackingSlipDepartmentIsExpected(ps))), Times.Once);
        }

        [Test]
        public void ThenTheProductIsAddedToThePackingSlip()
        {
            _generatePackingSlipForPhysicalProduct.Apply(MockOrder.Object);

            MockOrder.Verify(m => m.SetPackingSlip(It.Is<PackingSlip>(ps => PackingSlipProductListIsExpected(ps))), Times.Once);
        }

        [Test]
        public void ThenAPackingSlipCreatedEventIsPublishedToTheServiceBus()
        {
            _generatePackingSlipForPhysicalProduct.Apply(MockOrder.Object);

            MockServiceBus.Verify(m => m.PublishEvent(It.Is<PackingSlipCreated>(psc => PackingSlipIsMatch(psc))), Times.Once());
        }

        private bool PackingSlipIsMatch(PackingSlipCreated createdEvent)
        {
            var packingSlip = createdEvent.Data as PackingSlip;
            
            if (packingSlip == null)
            {
                Assert.Fail("Packing Slip Created Event did not have a packing slip.");
            }

            if (packingSlip.Department != "Shipping")
            {
                Assert.Fail("Packing slip department should be Shipping");
            }

            return true;
        }
    }
}