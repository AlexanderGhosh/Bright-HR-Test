using Kata.Checkout.Promotions;

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
        public static ICatalogue DefaultNoPromotions => new Catalogue(new()
        {
            { "A", new(50) },
            { "B", new(30) },
            { "C", new(20) },
            { "D", new(15) }
        });
        public static ICatalogue Default => new Catalogue(new()
        {
            { "A", new(50, new MultiBuyPromotion(3, 130)) },
            { "B", new(30, new MultiBuyPromotion(2, 45)) },
            { "C", new(20) },
            { "D", new(15) }
        });

        /// <summary>
        /// Generates a catalogue with no products
        /// </summary>
        public static ICatalogue Empty => new Catalogue([]);
    }
}
