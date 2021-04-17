using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAPackingSlipDuplicated
    {
        private PackingSlipDuplicated _packingSlipDuplicatedEvent;
        private PackingSlip _expectedPackingSlip;

        [SetUp]
        public void Setup()
        {
            _expectedPackingSlip = new PackingSlip("Expected Department");
            _packingSlipDuplicatedEvent = new PackingSlipDuplicated(_expectedPackingSlip, "Expected Order Id");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _packingSlipDuplicatedEvent.Message.Should().Be("Expected Order Id: Packing slip DUPLICATED for Expected Department.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _packingSlipDuplicatedEvent.Data.Should().BeEquivalentTo(_expectedPackingSlip);
        }
    }
}