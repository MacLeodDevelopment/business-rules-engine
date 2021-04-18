using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAGenerateCommissionPayment
{
    [TestFixture]
    public class WhenApplyIsInvoked
    {
        private GenerateCommissionPayment _generateCommissionPayment;
        private Mock<IServiceBus> _mockServiceBus;
        private Mock<Order> _mockOrder;

        [SetUp]
        public void Setup()
        {
            _mockOrder = new Mock<Order>();
            _mockOrder.SetupGet(m => m.Id).Returns("Expected Order Id");
            _mockOrder.SetupGet(m => m.AgentId).Returns("Expected Agent Id");

            _mockServiceBus = new Mock<IServiceBus>();
            
            _generateCommissionPayment = new GenerateCommissionPayment(_mockServiceBus.Object);
        }

        [Test]
        public void ThenACommissionPaymentGeneratedEventIsPublishedToTheServiceBus()
        {
            _generateCommissionPayment.Apply(_mockOrder.Object);

            _mockServiceBus.Verify(m => m.PublishEvent(It.Is<CommissionPaymentGenerated>(cpg => VerifyMatch(cpg))), Times.Once());
        }

        private bool VerifyMatch(CommissionPaymentGenerated actual)
        {
            actual.Data.ToString().Should().Be("Expected Agent Id");
            return true;
        }
    }
}