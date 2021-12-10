using OpenQA.Selenium;
using Testing.Pages;
using Testing.Pages.CatalogPages;

namespace Testing.Lib
{
    public class PageLib
    {
        private readonly IWebDriver _driver;

        //PageLibs
        public readonly ProductPageLib ProductPageLib;

        public PageLib(IWebDriver driver)
        {
            _driver = driver;
            ProductPageLib = new ProductPageLib(driver);
        }

        public CatalogPage CatalogPage => new CatalogPage(_driver);
        public HomePage HomePage => new HomePage(_driver);
        public AccountPage AccountPage => new AccountPage(_driver);
        public LoginPage LoginPage => new LoginPage(_driver);
        public OrderingPage OrderingPage => new OrderingPage(_driver);
        public FileTestPage FileTestPage => new FileTestPage(_driver);
    }
}