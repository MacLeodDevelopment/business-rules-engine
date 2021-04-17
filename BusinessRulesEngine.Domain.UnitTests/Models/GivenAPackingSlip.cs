using System.Linq;
using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Models
{
    [TestFixture]
    public class GivenAPackingSlip
    {
        private PackingSlip _packingSlip;

        [SetUp]
        public void Setup()
        {
            _packingSlip = new PackingSlip("Expected");
        }

        [Test]
        public void ThenDepartmentIsSetFromTheConstructor()
        {
            _packingSlip.Department.Should().Be("Expected");
        }

        [Test]
        public void WhenAddProductIsInvoked_ThenTheProductIsAddedToTheListOfProductNames()
        {
            _packingSlip.AddProduct("Expected Product");

            _packingSlip.Products.Count.Should().Be(1);
            _packingSlip.Products.Single().Should().Be("Expected Product");
        }
    }
}