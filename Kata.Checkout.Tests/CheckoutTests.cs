namespace Kata.Checkout.Tests
{
    public class Tests
    {
        private ICheckout _checkout;
        [SetUp]
        public void Setup()
        {
            _checkout = null;
        }

        [Test]
        public void Checkout_Empty_ReturnsZero()
        {
            int price = _checkout.GetTotalPrice();
            Assert.That(price, Is.EqualTo(0));
        }

        [Test]
        public void Checkout_Empty_Returns10()
        {
            _checkout.Scan("A");

            int price = _checkout.GetTotalPrice();
            Assert.That(price, Is.EqualTo(10));
        }
    }
}