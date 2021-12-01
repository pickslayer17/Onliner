using OpenQA.Selenium;

namespace Testing.Lib
{
    public class FlowLib
    {
        private IWebDriver _driver;

        public FlowLib(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoTo(string url)
        {
            _driver.Url = url;
        }

        public string GetCurrentUrl() => _driver.Url;

    }
}