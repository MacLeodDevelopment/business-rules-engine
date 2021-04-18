using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAGenerateCommissionPayment
{
    [TestFixture]
    public class WhenIsMatchIsInvoked
    {
        private GenerateCommissionPayment _generateCommissionPayment;
        private Order _orderWithPhysicalProduct;
        private Order _orderWithBook;
        private Order _orderWithAnythingElse;

        [SetUp]
        public void Setup()
        {
            _orderWithPhysicalProduct = new Order(new OrderConfig { Id = "Order With Physical Product" });
            _orderWithPhysicalProduct.SetProduct(new Product(new ProductConfig { Type = "Physical", SubType = "Video"}));

            _orderWithBook = new Order(new OrderConfig { Id = "Order With Book" });
            _orderWithBook.SetProduct(new Product(new ProductConfig{ SubType = "Book" }));

            _orderWithAnythingElse = new Order(new OrderConfig { Id = "Order With Anything Else" });
            _orderWithAnythingElse.SetProduct(new Product(new ProductConfig { Type = "Anything Else" }));

            _generateCommissionPayment = new GenerateCommissionPayment(new Mock<IServiceBus>().Object);
        }

        [Test]
        public void AndTheSuppliedProductIsPhysical_ThenTrueIsReturned()
        {
            var actual = _generateCommissionPayment.IsMatch(_orderWithPhysicalProduct);
            actual.Should().BeTrue();
        }
        
        [Test]
        public void AndTheSuppliedProductIsABook_ThenTrueIsReturned()
        {
            var actual = _generateCommissionPayment.IsMatch(_orderWithBook);
            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsNotPhysicalOrABook_ThenFalseIsReturned()
        {
            var actual = _generateCommissionPayment.IsMatch(_orderWithAnythingElse);
            actual.Should().BeFalse();
        }
    }
}