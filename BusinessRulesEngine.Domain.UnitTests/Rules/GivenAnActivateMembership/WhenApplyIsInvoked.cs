using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAnActivateMembership
{
    [TestFixture]
    public class WhenApplyIsInvoked 
    {
        private ActivateMembership _activateMembership;
        private Mock<IServiceBus> _mockServiceBus;
        private Mock<Order> _mockOrder;
        private Product _membershipActivation;

        [SetUp]
        public void Setup()
        {
            _membershipActivation = new Product(new ProductConfig {Id = "Expected Membership Id"});

            _mockOrder = new Mock<Order>();
            _mockOrder.SetupGet(m => m.Product).Returns(_membershipActivation);

            _mockServiceBus = new Mock<IServiceBus>();
            _activateMembership = new ActivateMembership(_mockServiceBus.Object);
        }

        [Test]
        public void ThenAnActivateMembershipEventIsPublishedToTheServiceBus()
        {
            _activateMembership.Apply(_mockOrder.Object);

            _mockServiceBus.Verify(
                m => m.PublishEvent(It.Is<MembershipActivated>(ma => ma.Data.ToString() == "Expected Membership Id")),
                Times.Once());
        }
    }
}