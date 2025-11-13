namespace Kata.Checkout
{
    /// <inheritdoc cref="ICatalogue"/>
    /// <param name="priceList">Mapping of SKUs to unit price</param>
    public class Catalogue(Dictionary<string, int> priceList) : ICatalogue
    {
        private readonly Dictionary<string, int> _priceList = priceList;
        int ICatalogue.GetPrice(string sku, int quantity)
        {
            return _priceList[sku] * quantity;
        }
    }
}
