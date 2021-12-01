using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing.Pages
{
    public abstract class AbstractPage
    {
        protected readonly IWebDriver _driver;

        protected AbstractPage(IWebDriver driver)
        {
            _driver = driver;
            WaitForPageLoad();
        }

        protected virtual void WaitForPageLoad()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.PageTimeout)).Until(
                ExpectedConditions.ElementExists(By.XPath("//body")));
        }

        public virtual bool IsLoaded()
        {
            return ((IJavaScriptExecutor) _driver).ExecuteScript("return document.readyState").Equals("complete");
        }
    }
}