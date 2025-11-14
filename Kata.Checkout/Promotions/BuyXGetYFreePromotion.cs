namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// When you want the price for <paramref name="buyX"/> + <paramref name="getY"/> items you get the price for <paramref name="buyX"/>
    /// </summary>
    public class BuyXGetYFreePromotion : IPromotion
    {
        private readonly int _payFor;
        private readonly int _getFree;

        /// <summary>
        /// Initializes an instance of <see cref="BuyXGetYFreePromotion"/> class with the given parameters for this promotion
        /// </summary>
        /// <param name="buyX">How many you will pay for</param>
        /// <param name="getY">How many you will not pay for</param>
        /// <exception cref="ArgumentException">Thrown when either <paramref name="buyX"/> or <paramref name="getY"/>is < 1></exception>
        public BuyXGetYFreePromotion(int buyX, int getY)
        {
            if (buyX < 1) throw new ArgumentException("buyX must be at least 1", nameof(buyX));
            if (getY < 1) throw new ArgumentException("getY must be at least 1", nameof(getY));
            _payFor = buyX;
            _getFree = getY;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentException">Thrown when <paramref name="quantity"/> is negative</exception>
        int IPromotion.ApplyPromotion(int unitPrice, int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
            int threshold = _payFor + _getFree;
            int fullSets = quantity / threshold;
            int remainingItems = quantity % threshold;
            int total = ((fullSets * _payFor) + remainingItems) * unitPrice;
            return total;
        }
    }

    /// <summary>
    /// Buy 1 get 1 free allies for <see cref="BuyXGetYFreePromotion"/>
    /// </summary>
    public class BuyOneGetOneFreePromotion() : BuyXGetYFreePromotion(1, 1);
}
