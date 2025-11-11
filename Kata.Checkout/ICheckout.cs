using Kata.Checkout.Promotions;

namespace Kata.Checkout
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
        void ApplyPromotion(IPromotion promotion);
    }
}
