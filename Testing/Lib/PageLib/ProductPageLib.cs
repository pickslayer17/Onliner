using OpenQA.Selenium;
using Testing.Pages.CatalogPages;

namespace Testing.Lib
{
    public class ProductPageLib
    {
        public readonly ComparePage ComparePage;
        public readonly ProductPage ProductPage;
        public readonly TvPage TvPage;

        public ProductPageLib(IWebDriver driver)
        {
            ProductPage = new ProductPage(driver);
            ComparePage = new ComparePage(driver);
            TvPage = new TvPage(driver);
        }
    }
}