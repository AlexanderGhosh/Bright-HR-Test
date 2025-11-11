namespace Kata.Checkout
{
    public class PromotionResult
    {
        public int TotalDiscount { get; set; } = 0;
        public List<string> AppliedSKUs { get; set; } = [];
        public List<string> AdditionalSKUs { get; set; } = [];
        public static PromotionResult Empty => new();
    }

    public class SaleProduct(IProduct product)
    {
        public IProduct Product { get; } = product;
        public int Quantity { get; set; } = 1;
        public (IProduct, int) Deconstruct() => (Product, Quantity);
    }
    public interface IPromotion
    {
        PromotionResult ApplyPromotion(params SaleProduct[] products);
    }
}
