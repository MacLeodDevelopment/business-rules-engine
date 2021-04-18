using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAPackingSlipUpdated
    {
        private PackingSlipUpdated _packingSlipUpdatedEvent;
        private PackingSlip _expectedPackingSlip;

        [SetUp]
        public void Setup()
        {
            _expectedPackingSlip = new PackingSlip("Expected Department");
            _packingSlipUpdatedEvent = new PackingSlipUpdated(_expectedPackingSlip, "Expected Order Id");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _packingSlipUpdatedEvent.Message.Should().Be("Expected Order Id: Packing slip UPDATED.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _packingSlipUpdatedEvent.Data.Should().BeEquivalentTo(_expectedPackingSlip);
        }
    }
}