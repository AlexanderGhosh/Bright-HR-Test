namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class CheckoutTests
    {
        private ICheckout _checkout;
        [SetUp]
        public void Setup()
        {
            _checkout = null;
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
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(50));
        }

        [Test]
        public void TotalPrice_AA_Returns100()
        {
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(100));
        }

        [Test]
        public void TotalPrice_AA_Returns150()
        {
            var totalPrice = _checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(150));
        }
    }
}
