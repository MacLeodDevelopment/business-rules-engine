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
        private Mock<ILogger> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _validOrder = new Order(new OrderConfig { Id = "An Order" });

            _expectedMatchingRules = new List<IRule>{ new TestRule() }; 
            _mockRuleMatchService = new Mock<IRuleMatchService>();
            _mockRuleMatchService.Setup(m => m.GetMatchingRules(_validOrder)).Returns(_expectedMatchingRules);
            
            _mockRuleEngine = new Mock<IRuleEngine>();
            _mockLogger = new Mock<ILogger>();

            _orderProcessor = new OrderProcessor(_mockRuleMatchService.Object, _mockRuleEngine.Object, _mockLogger.Object);
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

        [Test]
        public void AndTheRuleMatchServiceThrows_ThenTheExceptionIsLogged()
        {
            _mockRuleMatchService.Setup(m => m.GetMatchingRules(It.IsAny<Order>()))
                .Throws(new Exception("Rule Match Failure!"));

            _orderProcessor.ProcessOrder(_validOrder);

            _mockLogger.Verify(m => m.Log("An Order failed with error: Rule Match Failure!", MessageType.Error), Times.Once());
        }
        
        [Test]
        public void AndTheRuleEngineThrows_ThenTheExceptionIsLogged()
        {
            _mockRuleEngine.Setup(m => m.ApplyRules(It.IsAny<IEnumerable<IRule>>(), It.IsAny<Order>()))
                .Throws(new Exception("Rule Engine Failed!"));

            _orderProcessor.ProcessOrder(_validOrder);

            _mockLogger.Verify(m => m.Log("An Order failed with error: Rule Engine Failed!", MessageType.Error), Times.Once());
        }

        private class TestRule : IRule
        {
            public bool IsMatch(Order order)
            {
                return true;
            }

            public void Apply(Order order)
            {
                //Intentionally does nothing. 
            }
        }
    }
}