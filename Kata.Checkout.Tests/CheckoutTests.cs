using Kata.Checkout.Tests.Utils;

namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class CheckoutTests
    {
        [Test]
        public void TotalPrice_Z_ThrowMissingKey_ReturnsZero()
        {
            ICheckout checkout = new Checkout(CatalogueHelper.Default, 0, 0);
            Assert.That(() => checkout.Scan("Z"), Throws.TypeOf<KeyNotFoundException>());
            var totalPrice = checkout.GetTotalPrice();
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
        [TestCase(95, "B", "A", "B")]
        [TestCase(20, "C")]
        [TestCase(15, "D")]
        [TestCase(175, "A", "A", "A", "B", "B")]
        [TestCase(175, "A", "B", "A", "B", "A")]
        [TestCase(205, "A", "A", "A", "B", "B", "B")]
        [TestCase(260, "A", "A", "A", "B", "B", "B", "C", "C", "D")]
        public void TotalPrice_0_0_TestCases(int price, params string[] skus)
        {
            ICheckout checkout = new Checkout(CatalogueHelper.Default, 0, 0);
            foreach (var sku in skus)
            {
                checkout.Scan(sku);
            }
            var totalPrice = checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(price));
        }


        [Test]
        [TestCase(0)]
        [TestCase(50, "A")]
        [TestCase(100, "A", "A")]
        [TestCase(130, "A", "A", "A")]
        [TestCase(30, "B")]
        [TestCase(45, "B", "B")]
        [TestCase(75, "B", "B", "B")]
        [TestCase(95, "B", "A", "B")]
        [TestCase(20, "C")]
        [TestCase(15, "D")]
        [TestCase(180, "A", "A", "A", "B", "B")]
        [TestCase(180, "A", "B", "A", "B", "A")]
        [TestCase(215, "A", "A", "A", "B", "B", "B")]
        [TestCase(270, "A", "A", "A", "B", "B", "B", "C", "C", "D")]
        public void TotalPrice_5_5_TestCases(int price, params string[] skus)
        {
            ICheckout checkout = new Checkout(CatalogueHelper.Default, 5, 5);
            foreach (var sku in skus)
            {
                checkout.Scan(sku);
            }
            var totalPrice = checkout.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(price));
        }
    }
}
