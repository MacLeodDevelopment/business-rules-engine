using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAMembershipUpgraded
    {
        private MembershipUpgraded _membershipUpgradedEvent;

        [SetUp]
        public void Setup()
        {
            _membershipUpgradedEvent = new MembershipUpgraded("Expected Order Id", "Expected Membership Id");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _membershipUpgradedEvent.Message.Should().Be("Expected Order Id: Membership UPGRADED.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _membershipUpgradedEvent.Data.Should().BeEquivalentTo("Expected Membership Id");
        }
    }
}