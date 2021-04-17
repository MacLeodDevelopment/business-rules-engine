using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules
{
    /// <remarks>
    /// Some of the tests in here are more like integration tests.
    /// As the return type is void, we are reliant on some of the behaviour
    /// of PackingSlip to test the Apply method fully. Our other option
    /// is anemic (sic) domain models which some argue is an anti-pattern.
    /// </remarks>
    [TestFixture]
    public class GivenAGeneratePackingSlipForPhysicalProductWhenApplyIsInvoked
    {
        private GeneratePackingSlipForPhysicalProduct _generatePackingSlipForPhysicalProduct;
        private Mock<Order> _mockOrder;
        private PackingSlip _expectedPackingSlip;
        private Product _expectedProduct;

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

            _generatePackingSlipForPhysicalProduct = new GeneratePackingSlipForPhysicalProduct();
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

        private bool PackingSlipDepartmentIsExpected(PackingSlip actualPackingSlip)
        {
            Assert.AreEqual(_expectedPackingSlip.Department, actualPackingSlip.Department);
            return true; //This wil fail if they are not equal.
        }
        
        private bool PackingSlipProductListIsExpected(PackingSlip actualPackingSlip)
        {
            Assert.AreEqual(_expectedPackingSlip.Products, actualPackingSlip.Products);
            return true; //This wil fail if they are not equal.
        }
    }
}