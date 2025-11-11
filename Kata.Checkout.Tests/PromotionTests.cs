using Kata.Checkout.Promotions;

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
        public void Apply_1A1A1_Buy1Get1Free_NoDiscount1AdditionalSKU()
        {
            IPromotion promo = new BuyXGetYFree("A", "A", 1, 1, 1);
            PromotionResult result = promo.ApplyPromotion(_saleProducts);
            Assert.IsTrue(result.Applied);
            Assert.That(result.AppliedSKUs, Is.EquivalentTo(new[] { "A" }));
            Assert.That(result.AdditionalSKUs, Is.EquivalentTo(new[] { "A" }));
        }

        [Test]
        public void Apply_1A1A2_Buy1Get1Free_NoDiscount1AdditionalSKU()
        {
            IPromotion promo = new BuyXGetYFree("A", "A", 1, 1, 2);
            PromotionResult result = promo.ApplyPromotion(_saleProducts);
            Assert.IsTrue(result.Applied);
            Assert.That(result.AppliedSKUs, Is.EquivalentTo(new[] { "A" }));
            Assert.That(result.AdditionalSKUs, Is.EquivalentTo(new[] { "A", "A" }));
        }

        [Test]
        public void Apply_1A1B1_Buy1Get1Free_NoDiscount1AdditionalSKU()
        {
            IPromotion promo = new BuyXGetYFree("A", "B", 1, 1, 1);
            PromotionResult result = promo.ApplyPromotion(_saleProducts);
            Assert.IsTrue(result.Applied);
            Assert.That(result.AppliedSKUs, Is.EquivalentTo(new[] { "A" }));
            Assert.That(result.AdditionalSKUs, Is.EquivalentTo(new[] { "B" }));
        }

        //[Test]
        //public void Apply1_3MultiBuy_Discount30()
        //{
        //}

        //[Test]
        //public void Apply2_3MultiBuy_Discount30()
        //{
        //}

        //[Test]
        //public void Apply1_50PercentOff_Discount10()
        //{
        //}

        //[Test]
        //public void Apply2_50PercentOff_Discount10()
        //{
        //}
    }
}
