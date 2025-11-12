namespace Kata.Checkout
{
    /// <summary>
    /// Represents a shop checkout system<br/>
    /// You can scan in an SKU and determine the total price of the items in checkout
    /// </summary>
    public interface ICheckout
    {
        /// <summary>
        /// Adds <paramref name="sku"/> to the checkout
        /// </summary>
        /// <param name="sku">A unique product identifier</param>
        void Scan(string sku);

        /// <summary>
        /// Calculates the total price of all scanned items
        /// </summary>
        /// <returns>How much to pay</returns>
        int GetTotalPrice();
    }
}
