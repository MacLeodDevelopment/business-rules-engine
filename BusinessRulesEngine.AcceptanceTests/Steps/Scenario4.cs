using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario4
    {
        [Then(@"the membership is upgraded")]
        public void ThenTheMembershipIsUpgraded()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(2);

            var membershipUpgradeEvent = events[0];
            membershipUpgradeEvent.Message.Should().Be("MEMBERSHIP_UPGRADE_ORDER: Membership UPGRADED.");

            var membershipId = membershipUpgradeEvent.Data.ToString();

            membershipId.Should().Be("UPGRADE_MEMBER_ID");
        }
    }
}