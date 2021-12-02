using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Testing.Extensions;

namespace Testing.Pages.CatalogPages
{
    public class TvPage : AbstractProductPage
    {
        public TvPage(IWebDriver driver) : base(driver)
        {
        }

        private ReadOnlyCollection<IWebElement> _productImageLinkList =>
            WaitExtensions.WaitAndGetElements(_driver,
                By.XPath(
                    "//div[@class='schema-product__group']/div/div[3]/div[2]/div[@class='schema-product__title']"));

        public void ClickFirstInList() => _productImageLinkList[0].Click();


        public void ClickSecondInList() => _productImageLinkList[1].Click();
    }
}