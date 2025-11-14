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
        public void TotalPrice_Z_ThrowMissingKey_ReturnsZero()
        {
            Assert.That(() => _checkout.Scan("Z"), Throws.TypeOf<KeyNotFoundException>());
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(50, "A")]
        [TestCase(100, "A", "A")]
        [TestCase(130, "A", "A", "A")]
        [TestCase(30, "B")]
        [TestCase(45, "B", "B")]
        [TestCase(75, "B", "B","B")]
        [TestCase(20, "C")]
        [TestCase(15, "D")]
        [TestCase(175, "A", "A", "A", "B", "B")]
        [TestCase(175, "A", "B", "A", "B", "A")]
        [TestCase(205, "A", "A", "A", "B", "B", "B")]
        [TestCase(260, "A", "A", "A", "B", "B", "B", "C", "C", "D")]
        public void TotalPrice_TestCases(int price, params string[] skus)
        {
            foreach(var sku in skus)
            {
                _checkout.Scan(sku);
            }
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(price));
        }
    }
}
