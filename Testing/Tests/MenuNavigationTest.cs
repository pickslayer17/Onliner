using NUnit.Framework;

namespace Testing
{
    public class MenuNavigationTest : AbstractTest
    {
        [Test]
        public void VerifyCatalogPageIsLoaded()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.ClickCatalogLink();
            Assert.That(App.Pages.CatalogPage.IsLoaded, "Page is not loaded");
        }
    }
}