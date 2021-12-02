
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Testing.Pages
{
    public class CatalogPage : AbstractPage
    {
        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        private ReadOnlyCollection<IWebElement> _catalogTitles =>
            _driver.FindElements(By.XPath("//span[@class='catalog-navigation-classifier__item-title']"));
    }
}