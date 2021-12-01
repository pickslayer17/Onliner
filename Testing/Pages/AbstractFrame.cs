using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing.Pages
{
    public abstract class AbstractFrame
    {
        protected readonly IWebDriver _driver;

        protected AbstractFrame(IWebDriver driver, By locator)
        {
            _driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.FrameTimeout)).Until(
                ExpectedConditions.ElementIsVisible(locator));
            IWebElement frame = _driver.FindElement(locator);
            _driver.SwitchTo().Frame(frame);
        }
    }
}