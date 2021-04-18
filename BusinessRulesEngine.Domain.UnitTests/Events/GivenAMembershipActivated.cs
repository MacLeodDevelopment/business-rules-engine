using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAMembershipActivated
    {
        private MembershipActivated _membershipActivatedEvent;

        [SetUp]
        public void Setup()
        {
            _membershipActivatedEvent = new MembershipActivated("Expected Order Id", "Expected Membership Id");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _membershipActivatedEvent.Message.Should().Be("Expected Order Id: Membership ACTIVATED.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _membershipActivatedEvent.Data.Should().BeEquivalentTo("Expected Membership Id");
        }
    }
}