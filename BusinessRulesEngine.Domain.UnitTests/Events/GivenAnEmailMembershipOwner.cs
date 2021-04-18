using BusinessRulesEngine.Domain.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    [TestFixture]
    public class GivenAnEmailMembershipOwner
    {
        private EmailMembershipOwner _emailMembershipOwnerEvent;

        [SetUp]
        public void Setup()
        {
            _emailMembershipOwnerEvent = new EmailMembershipOwner("Expected Order Id", "Expected Membership Id", "Expected Topic");
        }

        [Test]
        public void ThenTheMessageIsSetCorrectly()
        {
            _emailMembershipOwnerEvent.Message.Should().Be("Expected Order Id: Membership Owner EMAILED about EXPECTED TOPIC.");
        }

        [Test]
        public void ThenTheDataIsSetCorrectly()
        {
            _emailMembershipOwnerEvent.Data.Should().BeEquivalentTo("Expected Membership Id");
        }
    }
}