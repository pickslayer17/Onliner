using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Testing.Extensions;


namespace Testing
{
    public class ProductSearchTest : AbstractTest
    {
        [Test]
        public void SearchProduct()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.WaitForPageLoad();
            App.Pages.HomePage.FillSearchInput(TestSettings.ProductName);

            List<string> productNames = App.Pages.HomePage.SearchFrame.GetProductNames();
            foreach (var name in productNames)
            {
                Console.Out.WriteLine(name);
                Assert.That(name.ContainsIgnoreCase(TestSettings.ProductName) || name.ContainsIgnoreCase(TestSettings.ProductNameAlt));
            }
        }
    }
}