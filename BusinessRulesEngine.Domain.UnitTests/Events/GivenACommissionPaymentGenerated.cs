using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenACommissionPaymentGenerated
    {
        private CommissionPaymentGenerated _commissionPaymentGeneratedEvent;
        
        [SetUp]
        public void Setup()
        {
            _commissionPaymentGeneratedEvent = new CommissionPaymentGenerated("Expected Order Id", "Expected Agent Id");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _commissionPaymentGeneratedEvent.Message.Should().Be("Expected Order Id: Commission PAYMENT GENERATED.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _commissionPaymentGeneratedEvent.Data.Should().BeEquivalentTo("Expected Agent Id");
        }
    }
}