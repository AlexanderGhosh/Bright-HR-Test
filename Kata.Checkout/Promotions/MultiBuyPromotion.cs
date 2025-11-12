namespace Kata.Checkout.Promotions
{
    public class MultiBuyPromotion : IPromotion
    {
        private readonly int _requiredQuantity;
        private readonly int _multiPrice;

        public MultiBuyPromotion(int requiredQuantity, int multiPrice)
        {
            if (requiredQuantity < 0) throw new ArgumentException("Required quantity cannot be negative", nameof(requiredQuantity));
            _requiredQuantity = requiredQuantity;
            _multiPrice = multiPrice;
        }

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
