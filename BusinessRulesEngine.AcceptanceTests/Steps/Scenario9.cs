using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario9
    {
        [Then(@"a commission payment is generated for the book agent")]
        public void ThenACommissionPaymentIsGeneratedForTheBookAgent()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().BeGreaterOrEqualTo(3);

            var packingSlipCreatedEvent = events[0];
            packingSlipCreatedEvent.Message.Should().Be("BOOK_ORDER: Packing slip CREATED for Shipping.");
            
            var duplicatePackingSlipCreatedEvent = events[1];
            duplicatePackingSlipCreatedEvent.Message.Should().Be("BOOK_ORDER: Packing slip DUPLICATED for Royalty Department.");

            var generateCommissionEvent = events[2];
            generateCommissionEvent.Message.Should().Be("BOOK_ORDER: Commission PAYMENT GENERATED.");

            var agentId = generateCommissionEvent.Data.ToString();

            agentId.Should().Be("BOOK_AGENT_ID");
        }
    }
}