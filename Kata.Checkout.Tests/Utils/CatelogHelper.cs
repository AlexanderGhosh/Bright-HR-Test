namespace Kata.Checkout.Tests.Utils
{
    internal class CatalogueHelper
    {
        /// <summary>
        /// Generates a catalogue with the following products
        /// <list type="bullet">
        /// <item>A 50</item>
        /// <item>B 30</item>
        /// <item>C 20</item>
        /// <item>D 15</item>
        /// </list>
        /// </summary>
        public static ICatalogue Default => new Catalogue(new()
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        });

        /// <summary>
        /// Generates a catalogue with no products
        /// </summary>
        public static ICatalogue Empty => new Catalogue([]);
    }
}
