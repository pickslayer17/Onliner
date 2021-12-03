using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing.Pages.CatalogPages
{
    public class AccountPage : HomePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }
        private By _profileImageDivBy => By.XPath("//div[contains(@class, 'b-top-profile__image')]");
        
        private IWebElement _profileImageDiv =>
            _driver.FindElement(_profileImageDivBy);
        protected override bool WaitForPageLoad()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.ElementTimeout)).Until(
                ExpectedConditions.ElementExists(_profileImageDivBy));
            return _driver.Url == TestSettings.HomeUrl;
        }
    }
}