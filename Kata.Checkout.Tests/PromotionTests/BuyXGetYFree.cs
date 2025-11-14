using Kata.Checkout.Promotions;

namespace Kata.Checkout.Tests.PromotionTests
{
    [TestFixture]
    internal class BuyXGetYFree
    {
        [Test]
        public void Constructor_Buy1GetLT1Free_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BuyXGetYFreePromotion(1, 0));
            Assert.Throws<ArgumentException>(() => new BuyXGetYFreePromotion(1, -1));
        }
        [Test]
        public void Constructor_BuyLT1Get1Free_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BuyXGetYFreePromotion(0, 1));
            Assert.Throws<ArgumentException>(() => new BuyXGetYFreePromotion(-1, 1));
        }
        [Test]
        public void ApplyPromotion_Buy1Get1Free_NegativeQuantity_ThrowsArgumentException()
        {
            IPromotion promotion = new BuyXGetYFreePromotion(1, 1);
            Assert.Throws<ArgumentException>(() => promotion.ApplyPromotion(0, -1));
        }

        [Test]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 1)]
        [TestCase(1, 3, ExpectedResult = 2)]
        [TestCase(1, 4, ExpectedResult = 2)]
        public int ApplyPromotion_Buy1Get1Free_TestCases(int unitPrice, int quantity)
        {
            IPromotion promotion = new BuyXGetYFreePromotion(1, 1);
            return promotion.ApplyPromotion(unitPrice, quantity);
        }

        [Test]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(1, 4, ExpectedResult = 2)]
        public int ApplyPromotion_Buy1Get2Free_TestCases(int unitPrice, int quantity)
        {
            IPromotion promotion = new BuyXGetYFreePromotion(1, 2);
            return promotion.ApplyPromotion(unitPrice, quantity);
        }

        [Test]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(1, 3, ExpectedResult = 2)]
        [TestCase(1, 4, ExpectedResult = 3)]
        public int ApplyPromotion_Buy2Get1Free_TestCases(int unitPrice, int quantity)
        {
            IPromotion promotion = new BuyXGetYFreePromotion(2, 1);
            return promotion.ApplyPromotion(unitPrice, quantity);
        }

        [Test]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(1, 3, ExpectedResult = 3)]
        [TestCase(1, 4, ExpectedResult = 2)]
        public int ApplyPromotion_Buy2Get2Free_TestCases(int unitPrice, int quantity)
        {
            IPromotion promotion = new BuyXGetYFreePromotion(2, 2);
            return promotion.ApplyPromotion(unitPrice, quantity);
        }
    }
}
