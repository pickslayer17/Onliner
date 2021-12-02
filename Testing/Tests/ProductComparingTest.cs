using System.Collections.Generic;
using System.Threading;
using AngleSharp.Common;
using NUnit.Framework;
using Testing.Pages.CatalogPages;

namespace Testing
{
    public class ProductComparingTest : AbstractTest
    {
        [Test]
        public void CompareTwoProducts()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.ClickCatalogLink();
            App.Pages.CatalogPage.GoToTv();
            Thread.Sleep(10000); //todo remove

            //todo uncomment and todo
            // App.Pages.ProductPageLib.TvPage.ClickFirstInList();
            // App.Pages.ProductPageLib.ProductPage.CheckAddToCompare();
            // App.Flow.Back();
            // App.Pages.ProductPageLib.TvPage.ClickSecondInList();
            // App.Pages.ProductPageLib.ProductPage.CheckAddToCompare();
            // App.Pages.ProductPageLib.ProductPage.ClickComparePopup();
            // List<ProductCharacteristic> characteristicList1 = App.Pages.ProductPageLib.ComparePage.GetItemCharacteristicList(1);
            // List<ProductCharacteristic> characteristicList2 = App.Pages.ProductPageLib.ComparePage.GetItemCharacteristicList(1);
            // CompareCharacteristicLists(characteristicList1, characteristicList2);
        }

        private void CompareCharacteristicLists(List<ProductCharacteristic> list1, List<ProductCharacteristic> list2)
        {
            Assert.Multiple(() =>
            {
                for (var i = 0; i < list1.Count; i++)
                    Assert.That(list1.GetItemByIndex(i).Equals(list2.GetItemByIndex(i)),
                        $"Error while comparing\nItem: {list1.GetItemByIndex(i)}\n" +
                        $"with\nItem: {list2.GetItemByIndex(i)}");
            });
        }
    }
}