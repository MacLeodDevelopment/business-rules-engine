using System;
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
        private Mock<IRuleMatchService> _mockRuleMatchService;

        [SetUp]
        public void Setup()
        {
            _validOrder = new Order();
            _mockRuleMatchService = new Mock<IRuleMatchService>();

            _orderProcessor = new OrderProcessor(_mockRuleMatchService.Object);
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

        //This needs to take in orders, get any rules that apply and then apply them.
    }

    public interface IRuleMatchService
    {
        void GetMatchingRules(Order order);
    }

    public class OrderProcessor
    {
        private readonly IRuleMatchService _ruleMatchService;

        public OrderProcessor(IRuleMatchService ruleMatchService)
        {
            _ruleMatchService = ruleMatchService;
        }

        public void ProcessOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _ruleMatchService.GetMatchingRules(order);
        }
    }

    public class Order
    {
    }
}