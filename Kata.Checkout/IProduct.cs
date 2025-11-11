namespace Kata.Checkout
{
    // im pretty sure is overkill
    public interface IProduct
    {
        string SKU { get; }
        int Price { get; }
    }
}
