using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario3
    {
        [Then(@"the membership is activated")]
        public void ThenTheMembershipIsActivated()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(2);

            var membershipActivatedEvent = events[0];
            membershipActivatedEvent.Message.Should().Be("MEMBERSHIP_ACTIVATION_ORDER: Membership ACTIVATED.");

            var membershipId = membershipActivatedEvent.Data.ToString();

            membershipId.Should().Be("ACTIVATION_MEMBER_ID");
        }
    }
}