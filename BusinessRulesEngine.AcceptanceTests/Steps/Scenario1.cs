﻿using System.Linq;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario1
    {
        private readonly ScenarioContext _scenarioContext;

        public Scenario1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an order containing a physical product")]
        public void GivenAnOrderContainingAPhysicalProduct()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Physical_Product_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }
        
        [Then(@"a packing slip is generated for shipping the order")]
        public void ThenAPackingSlipIsGeneratedForShippingTheOrder()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().BeGreaterOrEqualTo(1);
            
            var packingSlipCreatedEvent = events[0];
            packingSlipCreatedEvent.Message.Should().Be("PHYSICAL_PRODUCT_ORDER: Packing slip CREATED for Shipping.");
            
            var packingSlip = packingSlipCreatedEvent.Data as PackingSlip;

            if (packingSlip == null)
            {
                Assert.Fail();
            }
            
            packingSlip.Department.Should().Be("Shipping");
            packingSlip.Products.Count.Should().Be(1);
            packingSlip.Products.Single().Should().Be("Battenberg (Cake)");
        }
    }
}