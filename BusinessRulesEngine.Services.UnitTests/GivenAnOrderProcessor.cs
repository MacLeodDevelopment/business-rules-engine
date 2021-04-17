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
        public void WhenProcessOrdersIsInvokedWithNullOrders_ThenAnArgumentNullExceptionIsThrown()
        {
            Action act = () => _orderProcessor.ProcessOrders(null);

            act.Should().Throw<ArgumentException>();
        }

        //This needs to take in orders, get any rules that apply and then apply them.
    }

    public class OrderProcessor
    {
        public void ProcessOrders(object o)
        {
            throw new NotImplementedException();
        }
    }
}