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

        [When(@"the order is processed")]
        public void WhenTheOrderIsProcessed()
        {
            var orders = _scenarioContext.Get<IEnumerable<InputOrder>>("Orders");
            UI.Program.ProcessOrders(orders);
        }
    }
}