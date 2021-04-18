using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario5
    {
        [Then(@"the owner is emailed and informed of the activation")]
        public void ThenTheOwnerIsEmailedAndInformedOfTheActivation()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(2);

            var emailOwnerEvent = events[1];
            emailOwnerEvent.Message.Should().Be("MEMBERSHIP_ACTIVATION_ORDER: Membership Owner EMAILED about ACTIVATE.");

            var membershipId = emailOwnerEvent.Data.ToString();

            membershipId.Should().Be("ACTIVATION_MEMBER_ID");
        }
    }
}