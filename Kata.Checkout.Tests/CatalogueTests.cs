using Kata.Checkout.Tests.Utils;

namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class CatalogueTests
    {
        [Test]
        public void GetPrice_InvalidSKU_ThrowsMissingKey()
        {
            Assert.Throws<KeyNotFoundException>(() => CatalogueHelper.Default.GetPrice("Z", 1));
        }

        [Test]
        public void GetPrice_EmptyCatalogue_ThrowsMissingKey()
        {
            Assert.Throws<KeyNotFoundException>(() => CatalogueHelper.Empty.GetPrice("A", 1));
        }

        [Test]
        [TestCase("A", 0, 0)]
        [TestCase("A", 1, 50)]
        [TestCase("A", 2, 100)]
        [TestCase("B", 0, 0)]
        [TestCase("B", 1, 30)]
        [TestCase("B", 2, 60)]
        [TestCase("C", 0, 0)]
        [TestCase("C", 1, 20)]
        [TestCase("C", 2, 40)]
        [TestCase("D", 0, 0)]
        [TestCase("D", 1, 15)]
        [TestCase("D", 2, 30)]
        public void GetPrice_NoPromotions_TestCases(string sku, int quantity, int excpected)
        {
            var price = CatalogueHelper.DefaultNoPromotions.GetPrice(sku, quantity);
            Assert.That(price, Is.EqualTo(excpected));
        }

        [TestCase("A", 0, 0)]
        [TestCase("A", 1, 50)]
        [TestCase("A", 2, 100)]
        [TestCase("A", 3, 130)]
        [TestCase("A", 4, 180)]
        [TestCase("A", 6, 260)]
        [TestCase("B", 0, 0)]
        [TestCase("B", 1, 30)]
        [TestCase("B", 2, 45)]
        [TestCase("B", 3, 75)]
        [TestCase("B", 4, 90)]
        [TestCase("C", 1, 20)]
        [TestCase("D", 1, 15)]
        public void GetPrice_WithPromotions_TestCases(string sku, int quantity, int excpected)
        {
            var price = CatalogueHelper.Default.GetPrice(sku, quantity);
            Assert.That(price, Is.EqualTo(excpected));
        }
    }
}
