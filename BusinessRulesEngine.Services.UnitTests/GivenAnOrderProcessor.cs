using System;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Services.UnitTests
{
    [TestFixture]
    public class GivenAnOrderProcessor
    {
        private OrderProcessor _orderProcessor;

        [SetUp]
        public void Setup()
        {
            _orderProcessor = new OrderProcessor();
        }

        [Test]
        public void WhenProcessOrderIsInvokedWithNullOrder_ThenAnArgumentNullExceptionIsThrown()
        {
            Action act = () => _orderProcessor.ProcessOrder(null);

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Value cannot be null. (Parameter 'order')");
        }

        //This needs to take in orders, get any rules that apply and then apply them.
    }

    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
        }
    }

    public class Order
    {
    }
}