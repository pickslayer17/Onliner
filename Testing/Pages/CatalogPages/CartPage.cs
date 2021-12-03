using OpenQA.Selenium;

namespace Testing.Pages.CatalogPages
{
    public class CartPage : AbstractProductPage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _firstGoToOrderingButton => _driver.FindElement(By.XPath(
            "(//div[@class='cart-form__offers-unit cart-form__offers-unit_primary'])[1]//div[contains(@class,'cart-form__offers-part_confirm')]//a"));

        public void ClickFirstProductGoToOrdering() => _firstGoToOrderingButton.Click();
    }
}