using System.Linq;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario3
    {
        private readonly ScenarioContext _scenarioContext;

        public Scenario3(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an order containing a membership")]
        public void GivenAnOrderContainingAMembership()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Order3_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }

        [Then(@"the membership is activated")]
        public void ThenTheMembershipIsActivated()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(1);

            var membershipActivatedEvent = events[0];
            membershipActivatedEvent.Message.Should().Be("Order3: Membership ACTIVATED.");

            var membershipId = membershipActivatedEvent.Data.ToString();

            membershipId.Should().Be("MEMBER001");
        }
    }
}