using Kata.Checkout.Promotions;

namespace Kata.Checkout
{
    /// <inheritdoc cref="ICatalogue"/>
    /// <param name="items">Mapping of SKUs to unit price and any promotions</param>
    public class Catalogue(Dictionary<string, CatalogueItem> items) : ICatalogue
    {
        private readonly Dictionary<string, CatalogueItem> _items = items;

        /// <summary>
        /// <inheritdoc/> with promotions applied
        /// </summary>
        /// <param name="sku"><inheritdoc/></param>
        /// <param name="quantity"><inheritdoc/></param>
        /// <returns>Returns the price for <paramref name="sku"/>|<paramref name="quantity"/> with promotions applied</returns>
        int ICatalogue.GetPrice(string sku, int quantity)
        {
            CatalogueItem item = _items[sku];
            if (item.Promotion is not null) 
                return item.Promotion.ApplyPromotion(item.UnitPrice, quantity);
            return item.UnitPrice * quantity;
        }
    }

    /// <summary>
    /// Represents the unit price and any promotion for a catalogue item
    /// </summary>
    /// <param name="UnitPrice">The price for 1 item</param>
    /// <param name="Promotion">The promotion (if any) applied to this item</param>
    public record CatalogueItem(int UnitPrice, IPromotion? Promotion = null);
}
