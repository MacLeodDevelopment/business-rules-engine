using System.Collections.Generic;
using System.Linq;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.UI.InputModels;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario2
    {
        private readonly ScenarioContext _scenarioContext;

        public Scenario2(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an order containing a book")]
        public void GivenAnOrderContainingABook()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Book_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }

        [Then(@"a duplicate packing slip is generated for the royalty department")]
        public void ThenADuplicatePackingSlipIsGeneratedForTheRoyaltyDepartment()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(2);
            
            var packingSlipDuplicatedEvent = events[1];
            packingSlipDuplicatedEvent.Message.Should().Be("BOOK_ORDER: Packing slip DUPLICATED for Royalty Department.");

            var packingSlip = packingSlipDuplicatedEvent.Data as PackingSlip;

            if (packingSlip == null)
            {
                Assert.Fail();
            }

            packingSlip.Department.Should().Be("Royalty Department");
            packingSlip.Products.Count.Should().Be(1);
            packingSlip.Products.Single().Should().Be("The Day of The Triffids (Book)");
        }
    }
}