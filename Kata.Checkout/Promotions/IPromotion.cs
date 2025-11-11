using System.ComponentModel;

namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// Represents the result of <see cref="IPromotion.ApplyPromotion(SaleProduct[])"/><br/>
    /// It keeps track of effective discount the promotion represents<br/>
    /// The SKUs this promotion was applied to<br/>
    /// And any additional SKUs this promotion wishes to include in the sale
    /// </summary>
    /// <remarks>You have to manage the additional SKUs</remarks>
    public class PromotionResult
    {
        /// <summary>
        /// The effective discount of the applied promotion
        /// </summary>
        /// <remarks>The amount that should be added to the sale total<br/>So a Negative value means an increase in price</remarks>
        public int TotalDiscount { get; set; } = 0;

        /// <summary>
        /// The SKUs the creating promotion was applied too
        /// </summary>
        public string[] AppliedSKUs { get; set; } = [];

        /// <summary>
        /// Any additional SKUs the creating promotion wishes to add to the sale
        /// </summary>
        public string[] AdditionalSKUs { get; set; } = [];
        /// <summary>
        /// True when this promotion has being applied to at least one SKU
        /// </summary>
        public bool Applied => AppliedSKUs.Length != 0;

        /// <summary>
        /// Short hand for not applying the promotion
        /// </summary>
        public static PromotionResult Empty => new();
    }

    /// <summary>
    /// Associates an <see cref="IProduct"/> with a quantity
    /// </summary>
    /// <param name="product">The product (to be) sold</param>
    /// <param name="quantity">The amount of <paramref name="product"/> (to be) sold</param>
    public class SaleProduct(IProduct product, int quantity = 1)
    {
        /// <summary>
        /// <inheritdoc cref="SaleProduct(IProduct, int)" path="/param[@name='product']"/>
        /// </summary>
        public IProduct Product { get; } = product;

        /// <summary>
        /// <inheritdoc cref="SaleProduct(IProduct, int)" path="/param[@name='quantity']"/>
        /// </summary>
        public int Quantity { get; set; } = quantity;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public (IProduct, int) Deconstruct() => (Product, Quantity);
    }

    /// <summary>
    /// Implementations should represent an operation on a set of products which can result in a discount or additional products being added to a sale
    /// </summary>
    public interface IPromotion
    {
        /// <summary>
        /// Applies this promotion in the context of <paramref name="products"/>
        /// </summary>
        /// <param name="products">The products this promotion can take into consideration <i>The Context</i></param>
        /// <remarks>This should be a pure function</remarks>
        /// <returns>The result of this promotion <see cref="PromotionResult"/></returns>
        PromotionResult ApplyPromotion(params SaleProduct[] products);
    }
}
