using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Models
{
    [TestFixture]
    public class GivenAnOrder
    {
        private Order _order;
        private PackingSlip _expectedPackingSlip;
        private Product _expectedProduct;

        [SetUp]
        public void Setup()
        {
            _expectedPackingSlip = new PackingSlip("Any Packing Slip");
            _expectedProduct = new Product(new ProductConfig{Name = "Any Product"});

            _order = new Order("An Order");
        }

        [Test]
        public void WhenSetPackingSlipIsInvoked_ThenThePackingSlipPropertyIsSet()
        {
            _order.SetPackingSlip(_expectedPackingSlip);

            _order.PackingSlip.Should().Be(_expectedPackingSlip);
        }

        [Test]
        public void WhenSetProductIsInvoked_ThenTheProductPropertyIsSet()
        {
            _order.SetProduct(_expectedProduct);

            _order.Product.Should().Be(_expectedProduct);
        }
    }
}