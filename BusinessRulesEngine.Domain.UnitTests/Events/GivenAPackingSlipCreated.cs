using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAPackingSlipCreated
    {
        private PackingSlipCreated _packingSlipCreatedEvent;
        private PackingSlip _expectedPackingSlip;

        [SetUp]
        public void Setup()
        {
            _expectedPackingSlip = new PackingSlip("Expected Department");
            _packingSlipCreatedEvent = new PackingSlipCreated(_expectedPackingSlip, "Expected Order Id");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _packingSlipCreatedEvent.Message.Should().Be("Expected Order Id: Packing slip CREATED for Expected Department.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _packingSlipCreatedEvent.Data.Should().BeEquivalentTo(_expectedPackingSlip);
        }
    }
}