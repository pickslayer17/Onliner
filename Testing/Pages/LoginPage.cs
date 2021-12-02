using OpenQA.Selenium;

namespace Testing.Pages
{
    public class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _emailInput =>
            _driver.FindElement(By.XPath("//input[@type='text' and contains(@class,'auth-input')]"));

        private IWebElement _passwordInput =>
            _driver.FindElement(By.XPath("//input[@type='password' and contains(@class,'auth-input')]"));

        private IWebElement _enterButton =>
            _driver.FindElement(By.XPath("//button[@type='submit' and contains(@class,'auth-button')]"));

        public void FillEmail(string name)
        {
            _emailInput.SendKeys(name);
        }

        public void FillPassword(string password)
        {
            _passwordInput.SendKeys(password);
        }

        public void ClickEnterButton()
        {
            _enterButton.Click();
        }
    }
}