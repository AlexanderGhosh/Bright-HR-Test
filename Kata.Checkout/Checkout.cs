namespace Kata.Checkout
{
    public class Checkout(ICatalogue catalogue) : ICheckout
    {
        // maps sku to quantity
        private readonly Dictionary<string, int> _scannedItems = [];
        private readonly ICatalogue _catalogue = catalogue;
        public void Scan(string sku)
        {
            _catalogue.GetPrice(sku); // to throw KeyNotFoundException if sku is invalid
            if (_scannedItems.TryGetValue(sku, out int value))
            {
                _scannedItems[sku] = ++value;
            }
            else
            {
                _scannedItems.Add(sku, 1);
            }
        }
        public int GetTotalPrice()
        {
            return _scannedItems.Sum(kvp => _catalogue.GetPrice(kvp.Key) * kvp.Value);
        }
    }
}
