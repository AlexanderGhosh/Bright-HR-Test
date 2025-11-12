namespace Kata.Checkout.Tests.Utils
{
    internal class CatalogueHelper
    {
        public static ICatalogue Default => new Catalogue(new()
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        });

        public static ICatalogue Empty => new Catalogue([]);
    }
}
