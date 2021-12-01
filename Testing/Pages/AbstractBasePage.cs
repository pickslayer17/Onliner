using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing.Pages
{
    public abstract class AbstractBasePage
    {
        private IWebDriver _driver;

        protected AbstractBasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public virtual void WaitForPageLoad()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.Timeout)).Until(
                ExpectedConditions.ElementExists(By.XPath("//body")));
        }
    }
}