using System.Collections.Generic;
using BusinessRulesEngine.UI.InputModels;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario1
    {
        [Given(@"an order containing a physical product")]
        public void GivenAnOrderContainingAPhysicalProduct()
        {
            
        }

        [When(@"the order is processed")]
        public void WhenTheOrderIsProcessed()
        {
            UI.Program.ProcessOrders(new List<Order>());
        }

        [Then(@"a packing slip is generated for shipping the order")]
        public void ThenAPackingSlipIsGeneratedForShippingTheOrder()
        {
            UI.Program.GetPublishedEvents();
        }
    }
}