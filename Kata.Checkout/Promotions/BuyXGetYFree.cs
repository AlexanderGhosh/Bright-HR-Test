namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// A general implementation of a Buy X Get Y Free<br/>
    /// Where the quantity of X or Y is variable as well as the SKUs required and added
    /// </summary>
    /// <param name="requiredSKU">The SKU required for this promotion to take effect</param>
    /// <param name="freeSKU">The SKU that will be added should this promotion be applied</param>
    /// <param name="buyX">The number of <paramref name="requiredSKU"/> that must be found before adding any <paramref name="freeSKU"/></param>
    /// <param name="getY">The number of <paramref name="freeSKU"/> that will be added if the promotion is applied</param>
    /// <param name="maxRedemptions">The number of times this promotion can be applied</param>
    /// <remarks><paramref name="maxRedemptions"/> Works like this<br/>
    /// if you do 'buy 1 get 1 free' and you buy 2 of the required SKUs<br/>
    /// if <paramref name="maxRedemptions"/> >= 2 then you will get 2 free items</remarks>
    public class BuyXGetYFree(string requiredSKU, string freeSKU, int buyX, int getY, int maxRedemptions) : IPromotion
    {
        private readonly string _requiredSKU = requiredSKU;
        private readonly string _freeSKU = freeSKU;
        private readonly int _buyX = buyX;
        private readonly int _getY = getY;
        private readonly int _maxRedemptions = maxRedemptions;

        /// <inheritdoc/>
        /// <remarks>This does not modify <paramref name="products"/> and does not apply a discount</remarks>
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

    /// <summary>
    /// Represents a 'Buy One Get One Free' promotion for <paramref name="sku"/>
    /// </summary>
    /// <param name="sku">The sku that is required and the sku which will be added for free</param>
    /// <param name="maxRedemptions"><inheritdoc cref="BuyXGetYFree.BuyXGetYFree(string, string, int, int, int)." path="/param[@name='maxRedemptions']"/></param>
    public class BuyOneGetOneFree(string sku, int maxRedemptions) : BuyXGetYFree(sku, sku, 1, 1, maxRedemptions);
}
