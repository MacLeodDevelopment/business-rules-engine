using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAMembershipEmail
{
    [TestFixture]
    public class WhenApplyIsInvoked
    {
        private MembershipEmail _membershipEmail;
        private Mock<IServiceBus> _mockServiceBus;

        private Mock<Order> _mockActivationOrder;
        private Product _membershipActivation;

        private Mock<Order> _mockUpgradeOrder;
        private Product _membershipUpgrade;

        [SetUp]
        public void Setup()
        {
            _membershipActivation = new Product(new ProductConfig { Id = "Expected Activation Id", SubType = "Activate"});
            _mockActivationOrder = new Mock<Order>();
            _mockActivationOrder.SetupGet(m => m.Product).Returns(_membershipActivation);

            _membershipUpgrade = new Product(new ProductConfig { Id = "Expected Upgrade Id", SubType = "Upgrade"});
            _mockUpgradeOrder = new Mock<Order>();
            _mockUpgradeOrder.SetupGet(m => m.Product).Returns(_membershipUpgrade);

            _mockServiceBus = new Mock<IServiceBus>();
            _membershipEmail = new MembershipEmail(_mockServiceBus.Object);
        }

        [Test]
        public void WithAnActivationOrder_ThenAnEmailMemberEventIsPublishedToTheServiceBus_WithAnActivationTopic()
        {
            _membershipEmail.Apply(_mockActivationOrder.Object);

            _mockServiceBus.Verify(
                m => m.PublishEvent(It.Is<EmailMembershipOwner>(ma => VerifyMatch(ma, _membershipActivation, "activate"))),
                Times.Once());
        }

        [Test]
        public void WithAnUpgradeOrder_ThenAnEmailMemberEventIsPublishedToTheServiceBus_WithAnUpgradeTopic()
        {
            _membershipEmail.Apply(_mockUpgradeOrder.Object);

            _mockServiceBus.Verify(
                m => m.PublishEvent(It.Is<EmailMembershipOwner>(ma => VerifyMatch(ma, _membershipUpgrade, "upgrade"))),
                Times.Once());
        }

        private bool VerifyMatch(EmailMembershipOwner actual, Product expectedProduct, string topic)
        {
            actual.Data.ToString().Should().Be(expectedProduct.Id);
            actual.Message.ToLowerInvariant().Should().Contain(topic);
            
            return true;
        }
    }
}