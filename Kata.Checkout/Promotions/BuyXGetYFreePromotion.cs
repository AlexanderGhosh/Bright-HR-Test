namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// When you want the price for <paramref name="buyX"/> + <paramref name="getY"/> items you get the price for <paramref name="buyX"/>
    /// </summary>
    /// <param name="buyX">How many you will pay for</param>
    /// <param name="getY">How many you will not pay for</param>
    public class BuyXGetYFreePromotion(int buyX, int getY) : IPromotion
    {
        private readonly int _payFor = buyX;
        private readonly int _getFree = getY;
        int IPromotion.ApplyPromotion(int unitPrice, int quantity)
        {
            return unitPrice * quantity;
        }
    }

    /// <summary>
    /// Buy 1 get 1 free allies for <see cref="BuyXGetYFreePromotion"/>
    /// </summary>
    public class BuyOneGetOneFreePromotion() : BuyXGetYFreePromotion(1, 1);
}
