using OpenQA.Selenium;
using Testing.Pages.CatalogPages;

namespace Testing.Lib
{
    public class ProductPageLib
    {
        private readonly IWebDriver _driver;
        public  ComparePage ComparePage => new ComparePage(_driver);
        public  ProductPage ProductPage => new ProductPage(_driver);
        public  TvPage TvPage => new TvPage(_driver);

        public ProductPageLib(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}