using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.UI.InputModels;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    [Binding]
    public class Scenario7
    {
        private readonly ScenarioContext _scenarioContext;

        public Scenario7(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an order containing a video")]
        public void GivenAnOrderContainingAVideo()
        {
            var orders = OrderHelper.GetOrderInput(SharedResources.Orders.Video_json);
            _scenarioContext.Add(StepConstants.OrdersKey, orders);
        }

        [Given(@"the title of the video is Learning to Ski")]
        public void GivenTheTitleOfTheVideoIs()
        {
            var orders = _scenarioContext.Get<IEnumerable<InputOrder>>(StepConstants.OrdersKey);
            orders.Single().ProductName.Should().Be("Learning to Ski");
        }

        [Given(@"and the order was placed after 1997")]
        public void GivenAndTheOrderWasPlacedAfter()
        {
            DateTime.Now.Year.Should().BeGreaterThan(1997);
        }

        [Then(@"a free First Aid video is added to the packing slip")]
        public void ThenAFreeFirstAidVideoIsAddedToThePackingSlip()
        {
            var events = UI.Program.GetPublishedEvents().ToList();
            events.Count.Should().Be(2);

            var packingSlipCreatedEvent = events[0];
            packingSlipCreatedEvent.Message.Should().Be("VIDEO_ORDER: Packing slip CREATED for Shipping.");

            var packingSlipUpdatedEvent = events[1];
            packingSlipUpdatedEvent.Message.Should().Be("VIDEO_ORDER: Packing slip UPDATED.");
            
            var packingSlip = packingSlipCreatedEvent.Data as PackingSlip;

            if (packingSlip == null)
            {
                Assert.Fail();
            }

            packingSlip.Department.Should().Be("Shipping");
            packingSlip.Products.Count.Should().Be(2);
            packingSlip.Products[0].Should().Be("Learning to Ski (Video)");
            packingSlip.Products[1].Should().Be("First Aid (Video)");
        }
    }
}