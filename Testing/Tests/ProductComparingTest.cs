using System.Collections.Generic;
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
            App.Pages.ProductPageLib.TvPage.ClickFirstInList();
            App.Pages.ProductPageLib.ProductPage.ClickAddToCompareCheckbox();
            App.Flow.Back();
            App.Pages.ProductPageLib.TvPage.ClickSecondInList();
            App.Pages.ProductPageLib.ProductPage.ClickAddToCompareCheckbox();
            App.Pages.ProductPageLib.ProductPage.ClickComparePopup();
            var characteristicList1 = App.Pages.ProductPageLib.ComparePage.GetItemCharacteristicList(0);
            var characteristicList2 = App.Pages.ProductPageLib.ComparePage.GetItemCharacteristicList(1);
            CompareCharacteristicLists(characteristicList1, characteristicList2);
        }

        private void CompareCharacteristicLists(List<ProductCharacteristic> list1, List<ProductCharacteristic> list2)
        {
            Assert.Multiple(() =>
            {
                for (var i = 0; i < list1.Count; i++)
                {
                    var item1 = list1.GetItemByIndex(i);
                    var item2 = list2.GetItemByIndex(i);
                    var failResult = string.Format($"Page row number - [{i}] \n- {item1}\n- {item2}");
                    Assert.That(item1.DifferentValuesHaveDifferentColors(item2),
                        "Error in items comparing:\n" + failResult);
                }
            });
        }
    }
}