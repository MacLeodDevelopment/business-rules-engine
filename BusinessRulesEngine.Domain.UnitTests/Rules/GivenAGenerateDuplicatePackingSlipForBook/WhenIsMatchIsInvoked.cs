using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessRulesEngine.Domain.UnitTests.Rules.GivenAGenerateDuplicatePackingSlipForBook
{
    /// <remarks>
    /// For expediency (time constraints) I have not added all of the tests that are in the
    /// GeneratePackingSlipForPhysicalProduct test fixture. In a real world app all of these
    /// cases would be covered - possibly with more error handling, too. 
    /// </remarks>
    [TestFixture]
    public class WhenIsMatchIsInvoked
    {
        private GenerateDuplicatePackingSlipForBook _generateDuplicatePackingSlipForBook;
        private Order _orderWithABook;
        private Order _orderWithNonBook;

        [SetUp]
        public void Setup()
        {
            _orderWithABook = new Order("Book Order");
            _orderWithABook.SetProduct(new Product(new ProductConfig{SubType = "Book"}));

            _orderWithNonBook = new Order("Other Order");
            _orderWithNonBook.SetProduct(new Product(new ProductConfig{SubType = "Other Product"}));

            _generateDuplicatePackingSlipForBook = new GenerateDuplicatePackingSlipForBook(new Mock<IServiceBus>().Object);
        }

        [Test]
        public void AndTheSuppliedProductIsABook_ThenTrueIsReturned()
        {
            var actual = _generateDuplicatePackingSlipForBook.IsMatch(_orderWithABook);

            actual.Should().BeTrue();
        }

        [Test]
        public void AndTheSuppliedProductIsNotPhysical_ThenFalseIsReturned()
        {
            var actual = _generateDuplicatePackingSlipForBook.IsMatch(_orderWithNonBook);
            actual.Should().BeFalse();
        }
    }
}