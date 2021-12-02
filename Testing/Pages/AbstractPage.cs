using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Testing.Extensions;

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

        protected virtual bool WaitForPageLoad()
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.PageTimeout)).Until(PageLoadConditions
                .IsLoadedReadyState);
        }

        public virtual bool IsLoaded()
        {
            return PageLoadConditions.IsLoadedReadyState(_driver);
        }
    }
}