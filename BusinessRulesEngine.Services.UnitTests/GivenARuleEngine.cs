using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Services.UnitTests
{
    [TestFixture]
    public class GivenARuleEngine
    {
        private RuleEngine _ruleEngine;
        private IEnumerable<IRule> _inputRules;
        private Order _validOrder;
        private readonly Mock<IRule> _mockRule1 = new Mock<IRule>();
        private readonly Mock<IRule> _mockRule2 = new Mock<IRule>();

        [SetUp]
        public void Setup()
        {
            _validOrder = new Order(new OrderConfig { Id = "An Order" });

            _mockRule1.Setup(m => m.Apply(_validOrder));
            _mockRule2.Setup(m => m.Apply(_validOrder));

            _inputRules = new List<IRule>
            {
                _mockRule1.Object, _mockRule2.Object
            };
            
            _ruleEngine = new RuleEngine();
        }

        [Test]
        public void WhenApplyRulesIsInvoked_ThenApplyIsInvokedOnEachRuleForTheOrder()
        {
            _ruleEngine.ApplyRules(_inputRules, _validOrder);

            _mockRule1.Verify(m => m.Apply(_validOrder), Times.Once);
            _mockRule2.Verify(m => m.Apply(_validOrder), Times.Once);
        }
    }
}