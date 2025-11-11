namespace Kata.Checkout.Promotions
{
    public class BuyXGetYFree(string requiredSKU, string freeSKU, int buyX, int getY, int maxRedemptions) : IPromotion
    {
        private readonly string _requiredSKU = requiredSKU;
        private readonly string _freeSKU = freeSKU;
        private readonly int _buyX = buyX;
        private readonly int _getY = getY;
        private readonly int _maxRedemptions = maxRedemptions;

        public PromotionResult ApplyPromotion(params SaleProduct[] products)
        {
            SaleProduct? product = products.FirstOrDefault(p => p.Product.SKU == _requiredSKU);
            if (product is null) return PromotionResult.Empty;

            int toApply = product.Quantity / _buyX;
            toApply = Math.Min(toApply, _maxRedemptions);

            return new PromotionResult()
            {
                AppliedSKUs = [_requiredSKU],
                AdditionalSKUs = [.. Enumerable.Repeat(_freeSKU, toApply * _getY)]
            };
        }
    }

    public class BuyOneGetOneFree(string sku) : BuyXGetYFree(sku, sku, 1, 1, int.MaxValue);
}
