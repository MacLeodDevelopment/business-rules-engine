using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using BusinessRulesEngine.Domain.UnitTests.Events;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAGenerateDuplicatePackingSlipForBook
{
    [TestFixture]
    public class WhenApplyIsInvoked : CommonApplyTestsSetupBase
    {
        private GenerateDuplicatePackingSlipForBook _generateDuplicatePackingSlipForBook;

        [SetUp]
        public new void Setup()
        {
            _generateDuplicatePackingSlipForBook = new GenerateDuplicatePackingSlipForBook();
        }

        [Test]
        public void ThenANewPackingSlipDuplicatedEventIsPublishedToTheServiceBus()
        {
            _generateDuplicatePackingSlipForBook.Apply(MockOrder.Object);

            MockServiceBus.Verify(m => m.PublishEvent(It.IsAny<IBusinessEvent>()), Times.Once());
            MockServiceBus.Verify(m => m.PublishEvent(It.Is<PackingSlipDuplicated>(psd => PackingSlipIsMatch(psd))), Times.Once());
        }

        private bool PackingSlipIsMatch(PackingSlipDuplicated duplicatedEvent)
        {
            var packingSlip = duplicatedEvent.Data as PackingSlip;

            if (packingSlip == null)
            {
                Assert.Fail("Packing Slip Duplicated Event did not have a packing slip.");
            }

            if (packingSlip.Department != "Royalty Department")
            {
                Assert.Fail("Packing slip department should be Royalty Department");
            }

            return true;
        }
    }
}