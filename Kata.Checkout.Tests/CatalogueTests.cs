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
            _catalogue = CatalogueHelper.Default;
        }

        [Test]
        public void GetPrice_InvalidSKU_ThrowsMissingKey()
        {
            Assert.Throws<KeyNotFoundException>(() => _catalogue.GetPrice("Z"));
        }

        [Test]
        public void GetPrice_Empty_ThrowsMissingKey()
        {
            _catalogue = CatalogueHelper.Empty;
            Assert.Throws<KeyNotFoundException>(() => _catalogue.GetPrice("A"));
        }

        [Test]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void GetPrice_x_ReturnsY(string x, int y)
        {
            var price = _catalogue.GetPrice(x);
            Assert.That(price, Is.EqualTo(y));
        }
    }
}
