namespace Kata.Checkout.Promotions
{
    public class MultiBuyPromotion(int requiredQuantity, int multiPrice) : IPromotion
    {
        private readonly int _requiredQuantity = requiredQuantity;
        private readonly int _multiPrice = multiPrice;
        int IPromotion.ApplyPromotion(int unitPrice, int quantity)
        {
            int toApply = quantity / _requiredQuantity;
            int notApplied = quantity % _requiredQuantity;
            int multi = _multiPrice * toApply;
            int single = unitPrice * notApplied;
            return multi + single;
        }
    }
}
