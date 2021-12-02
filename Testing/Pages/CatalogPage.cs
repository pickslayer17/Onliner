using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.ElementTimeout)).Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(
                    By.XPath("//span[@class='catalog-navigation-classifier__item-title']")
                )
            );

        public override bool IsLoaded()
        {
            return _catalogTitles.Any();
        }
    }
}