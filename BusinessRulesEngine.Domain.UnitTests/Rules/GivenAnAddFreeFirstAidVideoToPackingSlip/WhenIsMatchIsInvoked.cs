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
        private Order _orderWithAnythingElse;

        [SetUp]
        public void Setup()
        {
            _orderWithLearnToSkiVideo = new Order(new OrderConfig { Id = "Learning to Ski Video Order" });
            _orderWithLearnToSkiVideo.SetProduct(new Product(new ProductConfig { SubType = "Video", Name  = "Learning to Ski"}));

            _orderWithAnythingElse = new Order(new OrderConfig { Id = "Other Order" });
            _orderWithAnythingElse.SetProduct(new Product(new ProductConfig { SubType = "Other Product" }));

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
    }
}