using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAnUpgradeMembership
{
    [TestFixture]
    public class WhenIsMatchIsInvoked
    {
        private UpgradeMembership _upgradeMembership;
        private Order _upgradeMembershipOrder;
        private Order _anyOtherOrder;

        [SetUp]
        public void Setup()
        {
            var membership = new Product(new ProductConfig
            {
                Type = "Membership",
                SubType = "Upgrade"
            });

            _upgradeMembershipOrder = new Order("Test Upgrade Membership Order");
            _upgradeMembershipOrder.SetProduct(membership);

            _anyOtherOrder = new Order("Anything");
            _anyOtherOrder.SetProduct(new Product(new ProductConfig { Type = "Anything" }));

            _upgradeMembership = new UpgradeMembership(new Mock<IServiceBus>().Object);
        }

        [Test]
        public void AndTheSuppliedProductIsAMembershipUpgrade_ThenTrueIsReturned()
        {
            var actual = _upgradeMembership.IsMatch(_upgradeMembershipOrder);

            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsNotAMembershipUpgrade_ThenFalseIsReturned()
        {
            var actual = _upgradeMembership.IsMatch(_anyOtherOrder);

            actual.Should().BeFalse();
        }
    }
}