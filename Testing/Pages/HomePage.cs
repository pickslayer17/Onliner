using OpenQA.Selenium;

namespace Testing.Pages
{
    public class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _enterButton =>
            _driver.FindElement(By.XPath("//div[@id='userbar']//div[starts-with(@class,'auth-bar__item')][1]"));

        private IWebElement _searchInout => _driver.FindElement(By.XPath("//input[@class='fast-search__input']"));

        public SearchFrame SearchFrame => new SearchFrame(_driver, By.XPath("//iframe[@class='modal-iframe']"));


        public void ClickEnterButton() => _enterButton.Click();
        public void FillSearchInput(string text) => _searchInout.SendKeys(text);
    }
}