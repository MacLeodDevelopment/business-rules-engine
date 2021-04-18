using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAnUpgradeMembership
{
    [TestFixture]
    public class WhenApplyIsInvoked
    {
        private UpgradeMembership _upgradeMembership;
        private Mock<IServiceBus> _mockServiceBus;
        private Mock<Order> _mockOrder;
        private Product _membershipUpgrade;

        [SetUp]
        public void Setup()
        {
            _membershipUpgrade = new Product(new ProductConfig { Id = "Expected Membership Id" });

            _mockOrder = new Mock<Order>();
            _mockOrder.SetupGet(m => m.Product).Returns(_membershipUpgrade);

            _mockServiceBus = new Mock<IServiceBus>();
            _upgradeMembership = new UpgradeMembership(_mockServiceBus.Object);
        }

        [Test]
        public void ThenAnActivateMembershipEventIsPublishedToTheServiceBus()
        {
            _upgradeMembership.Apply(_mockOrder.Object);

            _mockServiceBus.Verify(
                m => m.PublishEvent(It.Is<MembershipUpgraded>(ma => ma.Data.ToString() == "Expected Membership Id")),
                Times.Once());
        }
    }
}