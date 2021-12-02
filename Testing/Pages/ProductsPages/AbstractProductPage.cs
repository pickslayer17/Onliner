using OpenQA.Selenium;

namespace Testing.Pages.CatalogPages
{
    public abstract class AbstractProductPage : AbstractPage
    {
        protected AbstractProductPage(IWebDriver driver) : base(driver)
        {
        }
    }
}