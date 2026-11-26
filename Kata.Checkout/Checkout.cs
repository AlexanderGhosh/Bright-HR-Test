namespace Kata.Checkout
{
    /// <inheritdoc cref="ICatalogue"/>
    public class Checkout : ICheckout
    {
        // maps sku to quantity
        private readonly Dictionary<string, int> _scannedItems = [];
        private readonly ICatalogue _catalogue;
        private readonly int _bagSize;
        private readonly int _bagPrice;


        /// <param name="catalogue">The catalogue to use for unit price lookups</param>
        public Checkout(ICatalogue catalogue)
        {
            _catalogue = catalogue;
            _bagSize = default;
            _bagPrice = default;
        }
        /// <param name="catalogue">The catalogue to use for unit price lookups</param>
        public Checkout(ICatalogue catalogue, int bagSize, int bagPrice)
        {
            _catalogue = catalogue;
            _bagSize = bagSize;
            _bagPrice = bagPrice;
        }

        void ICheckout.Scan(string sku)
        {
            // i might swap this to a concreate Catalogue implementation (or add a check sku to the interface)
            _catalogue.GetPrice(sku, 1); // to throw KeyNotFoundException if sku is invalid
            if (_scannedItems.TryGetValue(sku, out int value))
            {
                _scannedItems[sku] = ++value;
            }
            else
            {
                _scannedItems.Add(sku, 1);
            }
        }
        int ICheckout.GetTotalPrice()
        {
            int rawPrice = _scannedItems.Sum(kvp => _catalogue.GetPrice(kvp.Key, kvp.Value));
            int totalItems = _scannedItems.Sum(kvp => kvp.Value);
            return rawPrice + (totalItems % _bagSize) * _bagPrice;
        }
    }
}
