using OpenQA.Selenium;
using static Testing.Extensions.WaitExtensions;

namespace Testing.Pages
{
    public class OrderingPage : AbstractPage
    {
        public OrderingPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _orderingLogo =>
            WaitAndGet(_driver, By.XPath("(//div[contains(@class, 'cart-form__title')])[1]"));

        private IWebElement _anchorItemCourier => WaitAndGet(_driver, By.XPath("//div[@id='anchor-item_courier']"));

        public override bool IsLoaded() => _orderingLogo != null && _anchorItemCourier != null;
    }
}