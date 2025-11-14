using Kata.Checkout.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Checkout.Tests.PromotionTests
{
    [TestFixture]
    internal class FlatDiscountTests
    {
        [Test]
        public void Apply_NegativeQuantity_ThrowsArgumentException()
        {
            IPromotion promotion = new FlatDiscountPromotion(0);
            Assert.Throws<ArgumentException>(() => promotion.ApplyPromotion(1, -1));
        }

        [Test]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 1, ExpectedResult = 0)]
        [TestCase(0, 1, 1, ExpectedResult = -1)]
        [TestCase(1, 0, 1, ExpectedResult = 0)]
        [TestCase(10, 1, 5, ExpectedResult = 5)]
        [TestCase(10, 2, 5, ExpectedResult = 10)]
        [TestCase(-10, 1, 5, ExpectedResult = -15)]
        [TestCase(10, 1, -5, ExpectedResult = 15)]
        public int Apply_UnitPriceX_QuantityY_DiscountZ_ReturnsW(int unitCost, int quantity, int discount)
        {
            IPromotion promotion = new FlatDiscountPromotion(discount);
            int result = promotion.ApplyPromotion(unitCost, quantity);
            return result;
        }
    }
}
