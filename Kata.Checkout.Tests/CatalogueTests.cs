using Kata.Checkout.Tests.Utils;

namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class CatalogueTests
    {
        private ICatalogue _catalogue;
        [SetUp]
        public void Setup()
        {
            _catalogue = CatalogueHelper.DefaultNoPromotions;
        }

        [Test]
        public void GetPrice_InvalidSKU_ThrowsMissingKey()
        {
            Assert.Throws<KeyNotFoundException>(() => _catalogue.GetPrice("Z", 1));
        }

        [Test]
        public void GetPrice_Empty_ThrowsMissingKey()
        {
            _catalogue = CatalogueHelper.Empty;
            Assert.Throws<KeyNotFoundException>(() => _catalogue.GetPrice("A", 1));
        }

        [Test]
        [TestCase("A", 0, 0)]
        [TestCase("B", 0, 0)]
        [TestCase("C", 0, 0)]
        [TestCase("D", 0, 0)]
        [TestCase("A", 1, 50)]
        [TestCase("B", 1, 30)]
        [TestCase("C", 1, 20)]
        [TestCase("D", 1, 15)]
        [TestCase("A", 2, 100)]
        [TestCase("B", 2, 60)]
        [TestCase("C", 2, 40)]
        [TestCase("D", 2, 30)]
        public void GetPrice_SKU_Quantity_ReturnsZ_NoPromotions(string sku, int quantity, int excpected)
        {
            var price = _catalogue.GetPrice(sku, quantity);
            Assert.That(price, Is.EqualTo(excpected));
        }
    }
}
