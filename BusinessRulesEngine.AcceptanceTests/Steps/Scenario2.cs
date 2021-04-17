using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    public class Scenario2
    {
        [Given(@"an order containing a book")]
        public void GivenAnOrderContainingABook()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a duplicate packing slip is generated for the royalty department")]
        public void ThenADuplicatePackingSlipIsGeneratedForTheRoyaltyDepartment()
        {
            ScenarioContext.Current.Pending();
        }

    }
}