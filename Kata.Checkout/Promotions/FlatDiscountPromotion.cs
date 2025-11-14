using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Checkout.Promotions
{
    /// <summary>
    /// Represents a flat discount on a product
    /// </summary>
    /// <param name="unitDiscount">The discount to apply per unit</param>
    public class FlatDiscountPromotion(int unitDiscount) : IPromotion
    {
        private readonly int _unitDiscount = unitDiscount;
        int IPromotion.ApplyPromotion(int unitPrice, int quantity)
        {
            return (unitPrice - _unitDiscount) * quantity;
        }
    }
}
