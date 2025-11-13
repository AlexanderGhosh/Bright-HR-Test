namespace Kata.Checkout
{
    /// <summary>
    /// Associates SKUs with their prices
    /// </summary>
    public interface ICatalogue
    {
        /// <summary>
        /// Gets the unit price of a product with the SKU <paramref name="sku"/>
        /// </summary>
        /// <param name="sku">The unique identifier for the desired product</param>
        /// <param name="quantity">The quantity of the product to get the price for</param>
        /// <returns>The unit price for <paramref name="sku"/></returns>
        int GetPrice(string sku, int quantity);
    }
}
