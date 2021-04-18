using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAMembershipEmail
{
    [TestFixture]
    public class WhenIsMatchIsInvoked
    {
        private MembershipEmail _membershipEmail;
        
        private Order _activateMembershipOrder;
        private Product _activateMembershipProduct;

        private Order _upgradeMembershipOrder;
        private Product _upgradeMembershipProduct;

        private Order _anyOtherOrder;
        
        [SetUp]
        public void Setup()
        {
            _activateMembershipProduct = new Product(new ProductConfig
            {
                Type = "Membership",
                SubType = "Activate"
            });

            _activateMembershipOrder = new Order(new OrderConfig { Id = "Test Activate Membership Order" });
            _activateMembershipOrder.SetProduct(_activateMembershipProduct);

            _upgradeMembershipProduct = new Product(new ProductConfig
            {
                Type = "Membership",
                SubType = "Upgrade"
            });

            _upgradeMembershipOrder = new Order(new OrderConfig { Id = "Test Upgrade Membership Order" });
            _upgradeMembershipOrder.SetProduct(_upgradeMembershipProduct);

            _anyOtherOrder = new Order(new OrderConfig { Id = "An Order" });
            _anyOtherOrder.SetProduct(new Product(new ProductConfig { Type = "Anything" }));

            _membershipEmail = new MembershipEmail(new Mock<IServiceBus>().Object);
        }

        [Test]
        public void AndTheSuppliedProductIsAMembershipActivation_ThenTrueIsReturned()
        {
            var actual = _membershipEmail.IsMatch(_activateMembershipOrder);

            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsAMembershipUpgrade_ThenTrueIsReturned()
        {
            var actual = _membershipEmail.IsMatch(_upgradeMembershipOrder);

            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsNotAMembershipUpgradeOrActivation_ThenFalseIsReturned()
        {
            var actual = _membershipEmail.IsMatch(_anyOtherOrder);

            actual.Should().BeFalse();
        }
    }
}