using OpenQA.Selenium;

namespace Testing.Lib
{
    public class AppLib
    {
        public readonly FlowLib Flow;
        public readonly PageLib Pages;

        public AppLib(IWebDriver driver)
        {
            Pages = new PageLib(driver);
            Flow = new FlowLib(driver);
        }
    }
}