using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Testing.Extensions;

namespace Testing.Pages.CatalogPages
{
    public class ProductPage : AbstractProductPage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _addToCompareCheckBox =>
            _driver.FindElement(By.XPath("//li[@id='product-compare-control']//span[@class='i-checkbox__faux']"));

        private IWebElement _comparePopup =>
            _driver.FindElement(
                By.XPath(
                    "//div[@id='compare-button-container']/div[@class='compare-button-container__inner']//div[contains(@class,'compare-button__state')]/a[contains(@class,'compare-button__sub_main')]"));

        private IWebElement _firstVendorAddToCartLink =>
            _driver.FindElement(By.XPath("(//div[@class='product-aside__main']/div/div)[1]/div/div/a[3]"));
        public void ClickAddToCompareCheckbox() => _addToCompareCheckBox.Click();
        public void ClickComparePopup() => _comparePopup.Click();
        public void ClickFirstVendorCart() => _firstVendorAddToCartLink.Click();

    }
}