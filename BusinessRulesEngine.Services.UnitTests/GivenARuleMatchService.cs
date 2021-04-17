using System.Collections.Generic;
using System.Linq;
using BusinessRulesEngine.Domain;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Services.UnitTests
{
    [TestFixture]
    public class GivenARuleMatchService
    {
        private RuleMatchService _ruleMatchService;
        private TestMatchingRule _expectedMatch;
        private Mock<IRuleRepository> _mockRuleRepository;

        [SetUp]
        public void Setup()
        {
            _expectedMatch = new TestMatchingRule();

            IEnumerable<IRule> allRules = new List<IRule>
            {
                new TestNonMatchingRule(),
                _expectedMatch,
                new TestNonMatchingRule()
            };

            _mockRuleRepository = new Mock<IRuleRepository>();
            _mockRuleRepository.Setup(m => m.AllRules()).Returns(allRules);

            _ruleMatchService = new RuleMatchService(_mockRuleRepository.Object);
        }

        [Test]
        public void ThenGetAllRulesIsInvokedOnTheRuleRepository()
        {
            _mockRuleRepository.Verify(m => m.AllRules(), Times.Once());
        }

        [Test]
        public void WhenGetMatchingRulesIsInvoked_ThenMatchingRulesAreReturned()
        {
            var actual = _ruleMatchService.GetMatchingRules(It.IsAny<Order>()).ToList();

            actual.Count.Should().Be(1);
            actual[0].Should().BeEquivalentTo(_expectedMatch);
        }

        private class TestMatchingRule : IRule
        {
            public bool IsMatch(Order order)
            {
                return true;
            }
        }
        
        private class TestNonMatchingRule : IRule
        {
            public bool IsMatch(Order order)
            {
                return false;
            }
        }
    }
}