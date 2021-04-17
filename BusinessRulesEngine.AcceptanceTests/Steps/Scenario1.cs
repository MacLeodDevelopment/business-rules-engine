﻿using System.Collections.Generic;
using System.Linq;
using BusinessRulesEngine.UI.InputModels;
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
            var order = new InputOrder(); //TODO AMACLEOD POPULATE FROM JSON? 
            var orders = new List<InputOrder> {order};

            _scenarioContext.Add("Orders", orders);
        }

        [When(@"the order is processed")]
        public void WhenTheOrderIsProcessed()
        {
            var orders = _scenarioContext.Get<IEnumerable<InputOrder>>("Orders");
            UI.Program.ProcessOrders(orders);
        }

        [Then(@"a packing slip is generated for shipping the order")]
        public void ThenAPackingSlipIsGeneratedForShippingTheOrder()
        {
            var events = UI.Program.GetPublishedEvents().ToList();

            events.Count.Should().Be(1);
            events[0].Message.Should().Be("Packing Slip Created");
        }
    }
}