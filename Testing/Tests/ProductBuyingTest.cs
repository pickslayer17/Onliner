using System.Threading;
using NUnit.Framework;

namespace Testing
{
    public class ProductBuyingTest : AbstractTest
    {
        [Test]
        public void BuyingWithCart()
        {
            Login();
            App.Pages.AccountPage.ClickCatalogLink();
            App.Pages.CatalogPage.GoToTv();
            App.Pages.ProductPageLib.TvPage.ClickFirstInList();
            App.Pages.ProductPageLib.ProductPage.ClickFirstVendorCart();
            Thread.Sleep(3000);

        }
        private void Login()
        {
            var user = TestSettings.UserName;
            var password = TestSettings.UserPassword;
            LoginUserPassword(user, password);
        }
        private void LoginUserPassword(string name, string password)
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.ClickEnterButton();
            App.Pages.LoginPage.FillEmail(name);
            App.Pages.LoginPage.FillPassword(password);
            App.Pages.LoginPage.ClickEnterButton();
        }
    }
}