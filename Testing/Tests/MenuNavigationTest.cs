using System.Threading;
using NUnit.Framework;

namespace Testing
{
    public class MenuNavigationTest : AbstractTest
    {
        [Test]
        public void VerifyCatalogPage()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.ClickCatalogLink();
            Assert.That(App.Pages.CatalogPage.IsLoaded());
            Thread.Sleep(2000);
            
        }
    }
}