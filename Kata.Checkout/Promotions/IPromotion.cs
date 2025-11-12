namespace Kata.Checkout.Promotions
{
    public interface IPromotion
    {
        int ApplyPromotion(int unitPrice, int quantity);
    }
}
