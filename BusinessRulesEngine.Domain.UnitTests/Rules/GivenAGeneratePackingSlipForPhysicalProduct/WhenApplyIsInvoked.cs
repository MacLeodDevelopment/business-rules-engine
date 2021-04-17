using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAGeneratePackingSlipForPhysicalProduct
{
    /// <remarks>
    /// Some of the tests in here are more like integration tests.
    /// As the return type is void, we are reliant on some of the behaviour
    /// of PackingSlip to test the Apply method fully. Our other option
    /// is anemic (sic) domain models which some argue is an anti-pattern.
    /// </remarks>
    [TestFixture]
    public class WhenApplyIsInvoked
    {
        private GeneratePackingSlipForPhysicalProduct _generatePackingSlipForPhysicalProduct;
        private Mock<Order> _mockOrder;
        private PackingSlip _expectedPackingSlip;
        private Product _expectedProduct;
        private Mock<IServiceBus> _mockServiceBus;

        [SetUp]
        public void Setup()
        {
            _expectedProduct = new Product(new ProductConfig
            {
                Name = "Expected Product",
                Type = "Expected Type",
                SubType = "Expected Sub Type"
            });

            _expectedPackingSlip = new PackingSlip("Shipping");
            _expectedPackingSlip.AddProduct($"{_expectedProduct.Name} ({_expectedProduct.ProductSubType})");

            _mockOrder = new Mock<Order>();
            _mockOrder.Setup(m => m.SetPackingSlip(_expectedPackingSlip));
            _mockOrder.SetupGet(m => m.Product).Returns(_expectedProduct);

            _mockServiceBus = new Mock<IServiceBus>();
            _mockServiceBus.Setup(m => m.PublishEvent(It.IsAny<IBusinessEvent>()));

            _generatePackingSlipForPhysicalProduct = new GeneratePackingSlipForPhysicalProduct(_mockServiceBus.Object);
        }

        [Test]
        public void ThenANewPackingSlipIsGeneratedAndAddedToTheOrder()
        {
            _generatePackingSlipForPhysicalProduct.Apply(_mockOrder.Object);

            _mockOrder.Verify(m => m.SetPackingSlip(It.Is<PackingSlip>(ps => PackingSlipDepartmentIsExpected(ps))), Times.Once);
        }

        [Test]
        public void ThenTheProductIsAddedToThePackingSlip()
        {
            _generatePackingSlipForPhysicalProduct.Apply(_mockOrder.Object);

            _mockOrder.Verify(m => m.SetPackingSlip(It.Is<PackingSlip>(ps => PackingSlipProductListIsExpected(ps))), Times.Once);
        }

        [Test]
        public void ThenAPackingSlipCreatedEventIsPublishedToTheServiceBus()
        {
            _generatePackingSlipForPhysicalProduct.Apply(_mockOrder.Object);

            _mockServiceBus.Verify(m => m.PublishEvent(It.IsAny<IBusinessEvent>()), Times.Once()); //TODO AMACLEOD REVISIT
        }

        private bool PackingSlipDepartmentIsExpected(PackingSlip actualPackingSlip)
        {
            Assert.AreEqual(_expectedPackingSlip.Department, actualPackingSlip.Department);
            return true; //This will fail if they are not equal.
        }
        
        private bool PackingSlipProductListIsExpected(PackingSlip actualPackingSlip)
        {
            Assert.AreEqual(_expectedPackingSlip.Products, actualPackingSlip.Products);
            return true; //This will fail if they are not equal.
        }
    }
}