using System.Linq;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAnAddFreeFirstAidVideoToPackingSlip
{
    [TestFixture]
    public class WhenApplyIsInvoked : CommonApplyTestsSetupBase
    {
        private AddFreeFirstAidVideoToPackingSlip _addFreeFirstAidVideoToPackingSlip;

        [SetUp]
        public new void Setup()
        {
            _addFreeFirstAidVideoToPackingSlip = new AddFreeFirstAidVideoToPackingSlip(MockServiceBus.Object);
        }

        [Test]
        public void ThenAPackingSlipUpdatedEventIsPublishedToTheServiceBus()
        {
            _addFreeFirstAidVideoToPackingSlip.Apply(MockOrder.Object);

            MockServiceBus.Verify(m => m.PublishEvent(It.Is<PackingSlipUpdated>(psd => PackingSlipIsMatch(psd))), Times.Once());
        }

        private bool PackingSlipIsMatch(PackingSlipUpdated actual)
        {
            var packingSlip = actual.Data as PackingSlip;

            if (packingSlip == null)
            {
                Assert.Fail("Packing Slip Updated Event did not have a packing slip.");
            }

            if (packingSlip.Products.Single() != "First Aid (Video)")
            {
                Assert.Fail("Packing slip should contain First Aid (Video).");
            }

            return true;
        }
    }
}