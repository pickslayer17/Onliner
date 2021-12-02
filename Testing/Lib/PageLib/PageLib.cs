using OpenQA.Selenium;
using Testing.Pages;

namespace Testing.Lib
{
    public class PageLib
    {
        //Pages
        public readonly CatalogPage CatalogPage;
        public readonly HomePage HomePage;

        public readonly LoginPage LoginPage;

        //PageLibs
        public readonly ProductPageLib ProductPageLib;

        public PageLib(IWebDriver driver)
        {
            //Pages
            HomePage = new HomePage(driver);
            LoginPage = new LoginPage(driver);
            CatalogPage = new CatalogPage(driver);
            //PageLibs
            ProductPageLib = new ProductPageLib(driver);
        }
    }
}