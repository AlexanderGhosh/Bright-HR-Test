namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class CheckoutTests
    {
        private ICheckout _checkout;
        [SetUp]
        public void Setup()
        {
            ICatalogue catalogue = new Catalogue(new()
            {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            });
            _checkout = new Checkout(catalogue);
        }

        [Test]
        public void TotalPrice_NoItems_ReturnsZero()
        {
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
    }
}
