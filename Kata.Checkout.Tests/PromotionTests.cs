namespace Kata.Checkout.Tests
{
    [TestFixture]
    internal class PromotionTests
    {
        private SaleProduct[] _saleProducts;
        [SetUp]
        public void Setup()
        {
            _saleProducts = [
                new(new Product("A", 10), 1),
                new(new Product("B", 15), 2),
                new(new Product("C", 20), 3),
            ];
        }

        [Test]
        public void Apply1_Buy1Get1Free_NoDiscount1AdditionalSKU()
        {
        }

        [Test]
        public void Apply2_Buy1Get1Free_NoDiscount1AdditionalSKU()
        {
        }

        [Test]
        public void Apply1_3MultiBuy_Discount30()
        {
        }

        [Test]
        public void Apply2_3MultiBuy_Discount30()
        {
        }

        [Test]
        public void Apply1_50PercentOff_Discount10()
        {
        }

        [Test]
        public void Apply2_50PercentOff_Discount10()
        {
        }
    }
}
