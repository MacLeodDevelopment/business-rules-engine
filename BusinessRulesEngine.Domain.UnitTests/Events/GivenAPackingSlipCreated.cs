using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAPackingSlipCreated
    {
        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            var packingSlipCreatedEvent = new PackingSlipCreated(new PackingSlip("Expected Department"), "Expected Order Id");

            packingSlipCreatedEvent.Message.Should().Be("Expected Order Id: Packing slip CREATED for Expected Department.");
        }
    }
}