using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario6
    {
        [Then(@"the owner is emailed and informed of the upgrade")]
        public void ThenTheOwnerIsEmailedAndInformedOfTheUpgrade()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(2);

            var emailOwnerEvent = events[1];
            emailOwnerEvent.Message.Should().Be("MEMBERSHIP_UPGRADE_ORDER: Membership Owner EMAILED about UPGRADE.");

            var membershipId = emailOwnerEvent.Data.ToString();

            membershipId.Should().Be("UPGRADE_MEMBER_ID");
        }
    }
}