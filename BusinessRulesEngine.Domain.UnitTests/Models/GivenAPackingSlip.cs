using BusinessRulesEngine.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Models
{
    [TestFixture]
    public class GivenAPackingSlip
    {
        [Test]
        public void ThenDepartmentIsSetFromTheConstructor()
        {
            var packingSlip = new PackingSlip("Expected");

            packingSlip.Department.Should().Be("Expected");
        }
    }
}