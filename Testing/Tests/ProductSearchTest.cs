using System;
using NUnit.Framework;
using static Testing.Extensions.StringExtensions;

namespace Testing
{
    public class ProductSearchTest : AbstractTest
    {
        [Test]
        public void SearchProduct()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.FillSearchInput(TestSettings.ProductName);
            var productNames = App.Pages.HomePage.SearchFrame.GetProductNames();
            foreach (var name in productNames)
            {
                Console.Out.WriteLine(name);
                Assert.That(
                    name.ContainsIgnoreCase(TestSettings.ProductName) ||
                    name.ContainsIgnoreCase(TestSettings.ProductNameAlt),
                    $"Expected: {TestSettings.ProductName} or {TestSettings.ProductNameAlt}\n " +
                    $"But was: {name}"
                );
            }
        }
    }
}