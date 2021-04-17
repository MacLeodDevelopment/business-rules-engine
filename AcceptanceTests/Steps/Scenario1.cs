using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
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
            
        }

        [Then(@"a packing slip is generated for shipping the order")]
        public void ThenAPackingSlipIsGeneratedForShippingTheOrder()
        {
            Assert.Fail("Test isn't implemented yet.");
        }
    }
}