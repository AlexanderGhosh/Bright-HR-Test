namespace Kata.Checkout.Tests
{
    internal sealed class Product(string sku, int price) : IProduct
    {
        public string SKU { get; } = sku;
        public int Price { get; } = price;
    }
}
