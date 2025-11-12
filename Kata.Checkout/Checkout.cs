namespace Kata.Checkout
{
    public class Checkout(ICatalogue catalogue) : ICheckout
    {
        // maps sku to quantity
        private readonly Dictionary<string, int> _scannedItems = [];
        private readonly ICatalogue _catalogue = catalogue;
        public void Scan(string sku)
        {
            _scannedItems[sku]++;
        }
        public int GetTotalPrice()
        {
            return _scannedItems.Sum(kvp => _catalogue.GetPrice(kvp.Key) * kvp.Value);
        }
    }
}
