using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing.Extensions
{
    public static class WaitExtensions
    {
        public static ReadOnlyCollection<IWebElement> WaitAndGetElements(IWebDriver driver, By locator) =>
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.ElementTimeout)).Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(locator
                )
            );

        public static IWebElement WaitAndGet(IWebDriver driver, By locator) =>
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.ElementTimeout)).Until(
                ExpectedConditions.ElementExists(locator
                )
            );
    }
}