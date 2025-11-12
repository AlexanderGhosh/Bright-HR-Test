namespace Kata.Checkout
{
    public class Catalogue(Dictionary<string, int> priceList) : ICatalogue
    {
        private readonly Dictionary<string, int> _priceList = priceList;
        public int GetPrice(string sku)
        {
            return _priceList["A"];
        }
    }
}
