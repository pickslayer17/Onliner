using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing.Pages
{
    public class CatalogPage : AbstractPage
    {
        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        private ReadOnlyCollection<IWebElement> _catalogTitles =>
            _driver.FindElements(By.XPath("//span[@class='catalog-navigation-classifier__item-title']"));

        public override bool IsLoaded()//if _catalogTitles elements exist, than it is This page
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.PageTimeout));
                foreach (var element in _catalogTitles)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));//there could be any other predicate verifies element exists by IWebElement
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}