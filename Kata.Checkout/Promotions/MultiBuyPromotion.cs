namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// When you buy a certain quantity of an item, you get it for a special price (usually a discount)
    /// </summary>
    public class MultiBuyPromotion : IPromotion
    {
        private readonly int _requiredQuantity;
        private readonly int _multiPrice;

        /// <summary>
        /// Initializes an instance of <see cref="MultiBuyPromotion"/> class with the given parameters for this promotion
        /// </summary>
        /// <param name="requiredQuantity">The amount of items you have to buy for the <paramref name="multiPrice"/> to be applied</param>
        /// <param name="multiPrice">When <paramref name="requiredQuantity"/> is met this is the price</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="requiredQuantity"/> is negative</exception>
        public MultiBuyPromotion(int requiredQuantity, int multiPrice)
        {
            if (requiredQuantity < 0) throw new ArgumentException("Required quantity cannot be negative", nameof(requiredQuantity));
            _requiredQuantity = requiredQuantity;
            _multiPrice = multiPrice;
        }

        /// <summary>
        /// Applies this promotion for every multiple of <c>requiredQuantity</c> this was constructed with
        /// </summary>
        /// <param name="unitPrice">The price for 1 item</param>
        /// <param name="quantity">How many items are being sold</param>
        /// <returns><inheritdoc/> with the promotion applied</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="quantity"/> is negative</exception>
        /// <remarks>Any items not valid for this promotion are charged at <paramref name="unitPrice"/></remarks>
        int IPromotion.ApplyPromotion(int unitPrice, int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
            int toApply = quantity / _requiredQuantity;
            int notApplied = quantity % _requiredQuantity;
            int multi = _multiPrice * toApply;
            int single = unitPrice * notApplied;
            return multi + single;
        }
    }
}
