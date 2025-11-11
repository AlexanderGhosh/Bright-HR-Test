using Kata.Checkout.Promotions;

namespace Kata.Checkout
{
    /// <summary>
    /// Represents a generic product which can have <see cref="IPromotion"/>s applied to it
    /// </summary>
    /// <remarks>I am pretty sure this is overkill for this lib but i am undecided about keeping it</remarks>
    public interface IProduct
    {
        /// <summary>
        /// A Unique identifier for this product
        /// </summary>
        string SKU { get; }

        /// <summary>
        /// The price for this product in base units
        /// </summary>
        /// <remarks>£1.00 = 100</remarks>
        int Price { get; }
    }
}
