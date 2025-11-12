namespace Kata.Checkout
{
    public interface IPromotion
    {
        int ApplyPromotion(int unitPrice, int quantity);
    }
}
