using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Testing
{
    [Binding]
    public class ProductBuyingTestSteps : AbstractBaseStep
    {
        
        [Given(@"I am on the LAStore homepage")]
        public void GivenThatIAmOnTheLAStoreHomepage()
        {
            LoginUserPassword(TestSettings.UserName, TestSettings.UserPassword);
        }
        
        [Given(@"I go to catalog")]
        public void GivenIGoToCatalog()
        {
            App.Pages.AccountPage.ClickCatalogLink();
        }
        
        [Given(@"I choose TV section")]
        public void GivenIChooseTVSection()
        {
            App.Pages.CatalogPage.GoToTv();
        }
        
        [Given(@"I choose the first one from the search list")]
        public void GivenIChooseTheFirstOneFromTheSearchList()
        {
            App.Pages.ProductPageLib.TvPage.ClickFirstInList();
        }
        
        [Given(@"I click ""(.*)"" button from the first vendor in the list")]
        public void GivenIClickButtonFromTheFirstVendorInTheList(string p0)
        {
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

        }
        
        [When(@"I Click ""(.*)""")]
        public void WhenIClick(string p0)
        {
            App.Pages.ProductPageLib.CartPage.ClickFirstProductGoToOrdering();
        }
        
        [Then(@"The Order page is loaded")]
        public void ThenTheOrderPageIsLoaded()
        {
            Assert.That(App.Pages.OrderingPage.IsLoaded(), "Page is not loaded");
        }


        
    }
}