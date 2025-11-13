namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// Represents a promotion that can be applied to a product
    /// </summary>
    /// <remarks>Traditionally it alters the price</remarks>
    public interface IPromotion
    {
        /// <summary>
        /// Applies this promotion's rules to the given <paramref name="unitPrice"/> and <paramref name="quantity"/>
        /// </summary>
        /// <param name="unitPrice">The unit price of the product</param>
        /// <param name="quantity">How many of the products are in the basket</param>
        /// <returns>The total to charge for <paramref name="quantity"/> this item</returns>
        /// <remarks>Basically gives you the price of this basket item</remarks>
        int ApplyPromotion(int unitPrice, int quantity);
    }
}
