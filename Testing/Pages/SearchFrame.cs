using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Testing.Pages
{
    public class SearchFrame : AbstractFrame
    {
        public SearchFrame(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        private ReadOnlyCollection<IWebElement> productLinks =>
            _driver.FindElements(By.XPath("//div[@class='product__title']/a[@target='_parent']"));

        private IWebElement _searchInput =>
            _driver.FindElement(By.XPath("//div[@id='search-page']//input[@class='search__input']"));

        public List<string> GetProductNames()
        {
            List<string> productNames = new List<string>();
            foreach (var element in productLinks)
            {
                productNames.Add(element.Text);
            }

            return productNames;
        }
    }
}