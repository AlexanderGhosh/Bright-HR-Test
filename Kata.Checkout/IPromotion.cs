namespace Kata.Checkout
{
    public class PromotionResult
    {
        public int TotalDiscount { get; set; } = 0;
        public List<string> AppliedSKUs { get; set; } = [];
        public List<string> AdditionalSKUs { get; set; } = [];
        public bool Applied => AppliedSKUs.Count != 0;
        public static PromotionResult Empty => new();
    }

    public class SaleProduct(IProduct product, int quantity = 1)
    {
        public IProduct Product { get; } = product;
        public int Quantity { get; set; } = quantity;
        public (IProduct, int) Deconstruct() => (Product, Quantity);
    }
    public interface IPromotion
    {
        PromotionResult ApplyPromotion(params SaleProduct[] products);
    }
}
