using OpenQA.Selenium;
using Testing.Pages;

namespace Testing.Lib
{
    public class PageLib
    {
        public readonly CatalogPage CatalogPage;
        public readonly HomePage HomePage;
        public readonly LoginPage LoginPage;

        public PageLib(IWebDriver driver)
        {
            HomePage = new HomePage(driver);
            LoginPage = new LoginPage(driver);
            CatalogPage = new CatalogPage(driver);
        }
    }
}