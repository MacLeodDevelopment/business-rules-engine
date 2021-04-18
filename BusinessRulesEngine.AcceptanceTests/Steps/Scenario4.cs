using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario4
    {
        private readonly ScenarioContext _scenarioContext;

        public Scenario4(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an order containing a membership upgrade")]
        public void GivenAnOrderContainingAMembershipUpgrade()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Order4_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }

        [Then(@"the membership is upgraded")]
        public void ThenTheMembershipIsUpgraded()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(1);

            var membershipUpgradeEvent = events[0];
            membershipUpgradeEvent.Message.Should().Be("Order4: Membership UPGRADED.");

            var membershipId = membershipUpgradeEvent.Data.ToString();

            membershipId.Should().Be("MEMBER002");
        }
    }
}