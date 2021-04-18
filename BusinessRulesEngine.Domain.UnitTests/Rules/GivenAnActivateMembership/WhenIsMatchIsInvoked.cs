using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAnActivateMembership
{
    [TestFixture]
    public class WhenIsMatchIsInvoked
    {
        private ActivateMembership _activateMembership;
        private Order _activateMembershipOrder;
        private Order _anyOtherOrder;

        [SetUp]
        public void Setup()
        {
            var membership = new Product(new ProductConfig
            {
                Type = "Membership",
                SubType = "Activate"
            });
            
            _activateMembershipOrder = new Order("Test Activate Membership Order");
            _activateMembershipOrder.SetProduct(membership);

            _anyOtherOrder = new Order("Anything");
            _anyOtherOrder.SetProduct(new Product(new ProductConfig{Type = "Anything"}));

            _activateMembership = new ActivateMembership(new Mock<IServiceBus>().Object);
        }

        [Test]
        public void AndTheSuppliedProductIsAMembershipActivation_ThenTrueIsReturned()
        {
            var actual = _activateMembership.IsMatch(_activateMembershipOrder);

            actual.Should().BeTrue();
        }
        
        [Test]
        public void AndTheSuppliedProductIsNotAMembershipActivation_ThenFalseIsReturned()
        {
            var actual = _activateMembership.IsMatch(_anyOtherOrder);

            actual.Should().BeFalse();
        }
    }
}