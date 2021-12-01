using NUnit.Framework;

namespace Testing
{
    public class MenuNavigationTest : AbstractTest
    {
        [Test]
        public void VerifyCataloguePage()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
        }
    }
}