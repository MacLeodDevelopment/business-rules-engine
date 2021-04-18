using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules
{
    [TestFixture]
    public class CommonApplyTestsSetupBase
    {
        protected Product ExpectedProduct;
        protected PackingSlip ExpectedPackingSlip;
        protected Mock<Order> MockOrder;
        protected Mock<IServiceBus> MockServiceBus;

        [SetUp]
        public void Setup()
        {
            ExpectedProduct = new Product(new ProductConfig
            {
                Name = "Expected Product",
                Type = "Expected Type",
                SubType = "Expected Sub Type"
            });

            ExpectedPackingSlip = new PackingSlip("Expected");
            
            MockOrder = new Mock<Order>();
            MockOrder.Setup(m => m.SetPackingSlip(ExpectedPackingSlip));
            MockOrder.SetupGet(m => m.Product).Returns(ExpectedProduct);
            MockOrder.SetupGet(m => m.PackingSlip).Returns(ExpectedPackingSlip);

            MockServiceBus = new Mock<IServiceBus>();
            MockServiceBus.Setup(m => m.PublishEvent(It.IsAny<IBusinessEvent>()));
        }

        protected bool PackingSlipDepartmentIsExpected(PackingSlip actualPackingSlip)
        {
            Assert.AreEqual(ExpectedPackingSlip.Department, actualPackingSlip.Department);
            return true; //This will fail if they are not equal.
        }

        protected bool PackingSlipProductListIsExpected(PackingSlip actualPackingSlip)
        {
            Assert.AreEqual(ExpectedPackingSlip.Products, actualPackingSlip.Products);
            return true; //This will fail if they are not equal.
        }
    }
}