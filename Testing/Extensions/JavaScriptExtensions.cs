using OpenQA.Selenium;

namespace Testing.Extensions
{
    public class JavaScriptExtensions
    {
        public const string GetAllCssPropertiesScript = "var s = '';" +
                                                        "var o = getComputedStyle(arguments[0]);" +
                                                        "for(var i = 0; i < o.length; i++){" +
                                                        "s+=o[i] + ':' + o.getPropertyValue(o[i])+';';}" +
                                                        "return s;";

        public static string ExecuteJS(IWebDriver driver, IWebElement element, string script) =>
            (string) ((IJavaScriptExecutor) driver)
            .ExecuteScript(script, element);
    }
}