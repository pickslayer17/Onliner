using OpenQA.Selenium;

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

        public void ClickAddToCompareCheckbox() => _addToCompareCheckBox.Click();

        public void ClickComparePopup() => _comparePopup.Click();
    }
}