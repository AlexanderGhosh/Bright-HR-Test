using Kata.Checkout.Tests.Utils;

namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class CheckoutTests
    {
        private ICheckout _checkout;
        [SetUp]
        public void Setup()
        {
            ICatalogue catalogue = CatalogueHelper.Default;
            _checkout = new Checkout(catalogue);
        }

        [Test]
        public void TotalPrice_NoItems_ReturnsZero()
        {
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        public void TotalPrice_Z_ThrowMissingKey_ReturnsZero()
        {
            Assert.That(() => _checkout.Scan("Z"), Throws.TypeOf<KeyNotFoundException>());
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        public void TotalPrice_A_Returns50()
        {
            _checkout.Scan("A");
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(50));
        }

        [Test]
        public void TotalPrice_AA_Returns100()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(100));
        }

        [Test]
        public void TotalPrice_AAA_Returns150()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(150));
        }

        [Test]
        public void TotalPrice_B_Returns30()
        {
            _checkout.Scan("B");
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(30));
        }

        [Test]
        public void TotalPrice_AB_Returns80()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(80));
        }

        [Test]
        public void TotalPrice_BA_Returns80()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(80));
        }
    }
}
