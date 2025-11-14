namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// Represents a percentage discount on a product
    /// </summary>
    /// <param name="discountMultiplier">The discount multiplier to apply per unit</param>
    public class PercentDiscountPromotion(float discountMultiplier) : IPromotion
    {
        private readonly float _discountMultiplier = discountMultiplier;
        /// <inheritdoc/>
        /// <remarks>Floors the result of the multiplier</remarks>
        /// <exception cref="ArgumentException">Thrown when <paramref name="quantity"/> is negative</exception>
        int IPromotion.ApplyPromotion(int unitPrice, int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
            return (int)(unitPrice * _discountMultiplier) * quantity;
        }
    }
}
