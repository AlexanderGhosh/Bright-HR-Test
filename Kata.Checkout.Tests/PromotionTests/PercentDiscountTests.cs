using Kata.Checkout.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Checkout.Tests.PromotionTests
{
    [TestFixture]
    internal class PercentDiscountTests
    {
        [Test]
        public void Apply_NegativeQuantity_ThrowsArgumentException()
        {
            IPromotion promotion = new PercentDiscountPromotion(0);
            Assert.Throws<ArgumentException>(() => promotion.ApplyPromotion(1, -1));
        }

        [Test]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 1, ExpectedResult = 0)]
        [TestCase(0, 1, 1, ExpectedResult = 0)]
        [TestCase(1, 0, 1, ExpectedResult = 0)]
        [TestCase(10, 1, 0.5f, ExpectedResult = 5)]
        [TestCase(10, 1, 0.1f, ExpectedResult = 1)]
        [TestCase(10, 1, 0.2f, ExpectedResult = 2)]
        [TestCase(10, 2, 0.3f, ExpectedResult = 6)]
        [TestCase(-10, 1, 0.5f, ExpectedResult = -5)]
        [TestCase(10, 1, -0.5f, ExpectedResult = -5)]
        [TestCase(10, 1, 1.5f, ExpectedResult = 15)]
        [TestCase(10, 2, 1.5f, ExpectedResult = 30)]
        [TestCase(21, 1, 0.4f, ExpectedResult = 8)]
        [TestCase(100, 1, 0.016f, ExpectedResult = 1, Description = "Check result is floored")]
        public int ApplyPromotion_TestCases(int unitCost, int quantity, float discount)
        {
            IPromotion promotion = new PercentDiscountPromotion(discount);
            int result = promotion.ApplyPromotion(unitCost, quantity);
            return result;
        }
    }
}

