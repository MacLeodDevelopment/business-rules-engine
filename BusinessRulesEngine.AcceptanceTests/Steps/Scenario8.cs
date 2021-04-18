using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario8
    {
        [Then(@"a commission payment is generated for the physical product agent")]
        public void ThenACommissionPaymentIsGeneratedForThePhysicalProductAgent()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().BeGreaterOrEqualTo(2);

            var packingSlipCreatedEvent = events[0];
            packingSlipCreatedEvent.Message.Should().Be("PHYSICAL_PRODUCT_ORDER: Packing slip CREATED for Shipping.");

            var generateCommissionEvent = events[1];
            generateCommissionEvent.Message.Should().Be("PHYSICAL_PRODUCT_ORDER: Commission PAYMENT GENERATED.");

            var agentId = generateCommissionEvent.Data.ToString();

            agentId.Should().Be("PHYSICAL_PRODUCT_AGENT_ID");
        }
    }
}