using System.Collections.Generic;
using BusinessRulesEngine.UI.InputModels;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Shared
    {
        private readonly ScenarioContext _scenarioContext;

        public Shared(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an order containing a membership")]
        public void GivenAnOrderContainingAMembership()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Membership_Activation_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }

        [Given(@"an order containing a membership upgrade")]
        public void GivenAnOrderContainingAMembershipUpgrade()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Membership_Upgrade_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }

        [When(@"the order is processed")]
        public void WhenTheOrderIsProcessed()
        {
            var orders = _scenarioContext.Get<IEnumerable<InputOrder>>(StepConstants.OrdersKey);
            UI.Program.ProcessOrders(orders);
        }
    }
}