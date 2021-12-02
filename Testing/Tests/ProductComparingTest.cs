using NUnit.Framework;

namespace Testing
{
    public class ProductComparingTest : AbstractTest
    {
        [Test]
        public void CompareTwoProducts()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            
        }
}
}