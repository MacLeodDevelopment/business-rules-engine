using System;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAnAddFreeFirstAidVideoToPackingSlip
{
    [TestFixture]
    public class WhenIsMatchIsInvoked
    {
        private AddFreeFirstAidVideoToPackingSlip _addFreeFirstAidVideoToPackingSlip;
        private Order _orderWithLearnToSkiVideo;
        private Product _learningToSkiVideo; 
        private Order _orderWithAnythingElse;
        private Mock<Order> _orderBefore1998;

        [SetUp]
        public void Setup()
        {
            _learningToSkiVideo = new Product(new ProductConfig {SubType = "Video", Name = "Learning to Ski"});

            _orderWithLearnToSkiVideo = new Order(new OrderConfig { Id = "Learning to Ski Video Order" });
            _orderWithLearnToSkiVideo.SetProduct(_learningToSkiVideo);

            _orderWithAnythingElse = new Order(new OrderConfig { Id = "Other Order" });
            _orderWithAnythingElse.SetProduct(new Product(new ProductConfig { SubType = "Other Product" }));

            _orderBefore1998 = new Mock<Order>();
            _orderBefore1998.SetupGet(m => m.Product).Returns(_learningToSkiVideo);
            _orderBefore1998.SetupGet(m => m.Timestamp).Returns(new DateTimeOffset(1997, 12, 31, 23, 59, 59, TimeSpan.Zero));
            
            _addFreeFirstAidVideoToPackingSlip = new AddFreeFirstAidVideoToPackingSlip(new Mock<IServiceBus>().Object);
        }

        [Test]
        public void AndTheSuppliedProductIsAVideoTitledLearningToSki_ThenTrueIsReturned()
        {
            var actual = _addFreeFirstAidVideoToPackingSlip.IsMatch(_orderWithLearnToSkiVideo);

            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsNotAVideoTitledLearnToSki_ThenFalseIsReturned()
        {
            var actual = _addFreeFirstAidVideoToPackingSlip.IsMatch(_orderWithAnythingElse);
            actual.Should().BeFalse();
        }

        [Test]
        public void AndTheOrderYearIsBefore1997OrEqualTo1997_ThenFalseIsReturned()
        {
            var actual = _addFreeFirstAidVideoToPackingSlip.IsMatch(_orderBefore1998.Object);
            actual.Should().BeFalse();
        }
    }
}