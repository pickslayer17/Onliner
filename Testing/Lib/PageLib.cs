using OpenQA.Selenium;
using Testing.Pages;

namespace Testing.Lib
{
    public class PageLib
    {
        public readonly HomePage HomePage;
        public PageLib(IWebDriver driver)
        {
            HomePage = new HomePage(driver);
        }
    }
}