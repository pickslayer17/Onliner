using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Testing.Extensions;

namespace Testing.Pages
{
    public class SearchFrame : AbstractFrame
    {
        public SearchFrame(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        private By _productLinksLocator = By.XPath("//div[@class='product__title']/a[@target='_parent']");//added because because ExpectedConditions.PresenceOfAllElementsLocatedBy doesn't support IWebElement but By only
        private ReadOnlyCollection<IWebElement> _productLinks =>
            _driver.FindElements(_productLinksLocator);

        public List<string> GetProductNames()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.ElementTimeout));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_productLinksLocator));
            List<string> productNames = new List<string>();
            foreach (var element in _productLinks)
            {
                
                productNames.Add(element.Text);
            }

            return productNames;
        }
    }
}