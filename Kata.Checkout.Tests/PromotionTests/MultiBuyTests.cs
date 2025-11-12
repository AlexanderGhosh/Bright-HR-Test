using Kata.Checkout.Promotions;

namespace Kata.Checkout.Tests.PromotionTests
{
    [TestFixture]
    internal class MultiBuyTests
    {
        [Test]
        public void Construct_PromoQuantMinus3_PromoPrice130_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(static () => new MultiBuyPromotion(-3, 130));
        }
        [Test]
        public void Apply_PromoQuant3_PromoPrice130_1_Minus1_ThrowsArgumentException()
        {
            IPromotion promotion = new MultiBuyPromotion(3, 130);
            Assert.Throws<ArgumentException>(() => promotion.ApplyPromotion(1, -1));
        }
        [Test]
        public void Construct_PromoQuant3_PromoPriceMinus130_Works()
        {
            Assert.DoesNotThrow(() => new MultiBuyPromotion(3, -130));
        }

        [Test]
        [TestCase(-50, 0, 0)]
        [TestCase(-50, 1, -50)]
        [TestCase(-50, 2, -100)]
        [TestCase(-50, 3, 130)]
        [TestCase(-50, 4, 80)]
        [TestCase(-50, 6, 260)]
        public void Apply_PromoQuant3_PromoPrice130_NegativeUnitPrice(int x, int y, int z)
        {
            IPromotion promotion = new MultiBuyPromotion(3, 130);
            Assert.That(promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }

        [Test]
        [TestCase(-30, 0, 0)]
        [TestCase(-30, 1, -30)]
        [TestCase(-30, 2, 45)]
        [TestCase(-30, 3, 15)]
        [TestCase(-30, 4, 90)]
        [TestCase(-30, 6, 135)]
        public void Apply_PromoQuant2_PromoPrice45_NegativeUnitPrice(int x, int y, int z)
        {
            IPromotion promotion = new MultiBuyPromotion(2, 45);
            Assert.That(promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(50, 0, 0)]
        [TestCase(50, 1, 50)]
        [TestCase(50, 2, 100)]
        [TestCase(50, 3, -130)]
        [TestCase(50, 4, -80)]
        [TestCase(50, 6, -260)]
        public void Apply_PromoQuant3_PromoPriceNegative130(int x, int y, int z)
        {
            IPromotion promotion = new MultiBuyPromotion(3, -130);
            Assert.That(promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(30, 0, 0)]
        [TestCase(30, 1, 30)]
        [TestCase(30, 2, -45)]
        [TestCase(30, 3, -15)]
        [TestCase(30, 4, -90)]
        [TestCase(30, 6, -135)]
        public void Apply_PromoQuant2_PromoPriceNegative45(int x, int y, int z)
        {
            IPromotion promotion = new MultiBuyPromotion(2, -45);
            Assert.That(promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(50, 0, 0)]
        [TestCase(50, 1, 50)]
        [TestCase(50, 2, 100)]
        [TestCase(50, 3, 130)]
        [TestCase(50, 4, 180)]
        [TestCase(50, 6, 260)]
        public void Apply_PromoQuant3_PromoPrice130(int x, int y, int z)
        {
            IPromotion promotion = new MultiBuyPromotion(3, 130);
            Assert.That(promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(30, 0, 0)]
        [TestCase(30, 1, 30)]
        [TestCase(30, 2, 45)]
        [TestCase(30, 3, 75)]
        [TestCase(30, 4, 90)]
        [TestCase(30, 6, 135)]
        public void Apply_PromoQuant2_PromoPrice45(int x, int y, int z)
        {
            IPromotion promotion = new MultiBuyPromotion(2, 45);
            Assert.That(promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }
    }
}
