using OpenQA.Selenium;

namespace Testing.Extensions
{
    public static class PageLoadConditions
    {
        public static bool IsLoadedReadyState(IWebDriver driver) => ((IJavaScriptExecutor) driver)
            .ExecuteScript("return document.readyState").Equals("complete");
    }
}