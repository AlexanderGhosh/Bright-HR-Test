namespace Kata.Checkout
{

    public interface IProduct
    {
        string SKU { get; }
        int Price { get; }
    }
}
