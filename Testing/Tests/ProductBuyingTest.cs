using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

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
            try
            {
                App.Pages.ProductPageLib.ProductPage.ClickToCartButton();
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.Out.WriteLine(
                    "Well, maybe there is no button, because the cart was not empty. Let's try next step.\n" + ex);
            }

            App.Pages.ProductPageLib.CartPage.ClickFirstProductGoToOrdering();
            Assert.That(App.Pages.OrderingPage.IsLoaded(), "Page is not loaded");
        }
        private void Login()
        {
            var user = TestSettings.UserName;
            var password = TestSettings.UserPassword;
            LoginUserPassword(user, password);
        }

        
    }
}