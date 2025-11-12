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
        public void GetPrice_A_Returns50()
        {
            var price = _catalogue.GetPrice("A");
            Assert.That(price, Is.EqualTo(50));
        }

        [Test]
        public void GetPrice_B_Returns30()
        {
            var price = _catalogue.GetPrice("B");
            Assert.That(price, Is.EqualTo(30));
        }

        [Test]
        public void GetPrice_C_Returns20()
        {
            var price = _catalogue.GetPrice("C");
            Assert.That(price, Is.EqualTo(20));
        }

        [Test]
        public void GetPrice_D_Returns15()
        {
            var price = _catalogue.GetPrice("D");
            Assert.That(price, Is.EqualTo(15));
        }
    }
}
