using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Testing.Extensions.PageLoadConditions;

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

        protected virtual bool WaitForPageLoad() =>
            new WebDriverWait(_driver, TimeSpan.FromSeconds(TestSettings.PageTimeout)).Until(
                IsLoadedReadyState);

        public virtual bool IsLoaded() => IsLoadedReadyState(_driver);
    }
}