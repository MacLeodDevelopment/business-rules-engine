using System.Collections.Generic;
using System.Linq;
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
        private Mock<IRuleRepository> _mockRuleRepository;
        private readonly Mock<IRule> _mockRule1 = new Mock<IRule>();
        private readonly Mock<IRule> _mockRule2 = new Mock<IRule>();
        private readonly Mock<IRule> _mockRule3 = new Mock<IRule>();
        private readonly Order _expectedOrder = new Order(new OrderConfig { Id = "Expected Order" });

        [SetUp]
        public void Setup()
        {
            _mockRule1.Setup(m => m.IsMatch(_expectedOrder)).Returns(false);
            _mockRule2.Setup(m => m.IsMatch(_expectedOrder)).Returns(true);
            _mockRule3.Setup(m => m.IsMatch(_expectedOrder)).Returns(false);

            IEnumerable<IRule> allRules = new List<IRule>
            {
                _mockRule1.Object,
                _mockRule2.Object,
                _mockRule3.Object
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
            var actual = _ruleMatchService.GetMatchingRules(_expectedOrder).ToList();

            actual.Count.Should().Be(1);
            actual[0].Should().BeEquivalentTo(_mockRule2.Object);
        }
    }
}