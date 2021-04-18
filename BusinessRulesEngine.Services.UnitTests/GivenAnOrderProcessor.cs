using System;
using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Services.UnitTests
{
    [TestFixture]
    public class GivenAnOrderProcessorWhenProcessOrderIsInvoked
    {
        private OrderProcessor _orderProcessor;
        private Order _validOrder;
        private IEnumerable<IRule> _expectedMatchingRules;
        private Mock<IRuleMatchService> _mockRuleMatchService;
        private Mock<IRuleEngine> _mockRuleEngine;

        [SetUp]
        public void Setup()
        {
            _validOrder = new Order(new OrderConfig { Id = "An Order" });

            _expectedMatchingRules = new List<IRule>(); //TODO AMACLEOD COME BACK AND ADD SOME TEST RULES
            _mockRuleMatchService = new Mock<IRuleMatchService>();
            _mockRuleMatchService.Setup(m => m.GetMatchingRules(_validOrder)).Returns(_expectedMatchingRules);
            
            _mockRuleEngine = new Mock<IRuleEngine>();

            _orderProcessor = new OrderProcessor(_mockRuleMatchService.Object, _mockRuleEngine.Object);
        }

        [Test]
        public void AndOrderIsNull_ThenAnArgumentNullExceptionIsThrown()
        {
            Action act = () => _orderProcessor.ProcessOrder(null);

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Value cannot be null. (Parameter 'order')");
        }

        [Test]
        public void WithAValidOrder_ThenGetMatchingRulesIsInvokedOnTheRuleMatchServiceWithTheOrder()
        {
            _orderProcessor.ProcessOrder(_validOrder);

            _mockRuleMatchService.Verify(m => m.GetMatchingRules(_validOrder), Times.Once());
        }

        [Test]
        public void AndThereAreSomeMatchingRules_ThenApplyRulesIsInvokedOnTheRuleEngineWithTheMatchingRulesAndTheOrder()
        {
            _orderProcessor.ProcessOrder(_validOrder);

            _mockRuleEngine.Verify(m => m.ApplyRules(_expectedMatchingRules, _validOrder), Times.Once());
        }
    }
}