using Kata.Checkout.Promotions;

namespace Kata.Checkout
{
    /// <inheritdoc cref="ICatalogue"/>
    /// <param name="items">Mapping of SKUs to unit price and any promotions</param>
    public class Catalogue(Dictionary<string, CatalogueItem> items) : ICatalogue
    {
        private readonly Dictionary<string, CatalogueItem> _items = items;
        int ICatalogue.GetPrice(string sku, int quantity)
        {
            CatalogueItem item = _items[sku];
            if (item.Promotion is not null) 
                return item.Promotion.ApplyPromotion(item.UnitPrice, quantity);
            return item.UnitPrice * quantity;
        }
    }

    public record CatalogueItem(int UnitPrice, IPromotion? Promotion = null);
}
