namespace Kata.Checkout.Tests.PromotionTests
{
    [TestFixture]
    internal class MultiBuyTests
    {
        private IPromotion _promotion;
        [SetUp]
        public void Setup()
        {
            _promotion = null;
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(50, 0, 0)]
        [TestCase(50, 1, 50)]
        [TestCase(50, 2, 100)]
        [TestCase(50, 3, 130)]
        [TestCase(50, 4, 180)]
        [TestCase(50, 6, 260)]
        [TestCase(30, 2, 45)]
        public void Apply_x_y_ReturnsZ(int x, int y, int z)
        {
            Assert.That(_promotion.ApplyPromotion(x, y), Is.EqualTo(z));
        }
    }
}
