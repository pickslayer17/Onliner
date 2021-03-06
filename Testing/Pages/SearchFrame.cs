
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using static Testing.Extensions.WaitExtensions;

namespace Testing.Pages
{
    public class SearchFrame : AbstractFrame
    {
        public SearchFrame(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        private ReadOnlyCollection<IWebElement> _productLinks => WaitAndGetElements(_driver,
            By.XPath("//div[@class='product__title']/a[@target='_parent']")
        );


        public List<string> GetProductNames()
        {
            var productNames = new List<string>();
            foreach (var element in _productLinks) productNames.Add(element.Text);
            return productNames;
        }
    }
}