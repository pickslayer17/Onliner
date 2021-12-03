using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using Testing.Extensions;

namespace Testing.Pages.CatalogPages
{
    public class ComparePage : AbstractProductPage
    {
        private const string _tableXpath = "//table[@id='product-table']";

        public ComparePage(IWebDriver driver) : base(driver)
        {
        }

        private ReadOnlyCollection<IWebElement> _tBodies =>
            WaitExtensions.WaitAndGetElements(_driver, By.XPath(string.Format("{0}/tbody", _tableXpath)));

        private ReadOnlyCollection<IWebElement> GetRowsFromBody(IWebElement body) =>
            body.FindElements(By.XPath("./tr[contains(@class, 'row_parameter')]"));

        private ReadOnlyCollection<IWebElement> GetCellsFromRow(IWebElement row) =>
            row.FindElements(By.XPath("./td/span"));

        public List<ProductCharacteristic> GetItemCharacteristicList(int index)
        {
            var productCharacteristics = new List<ProductCharacteristic>();
            foreach (var body in _tBodies)
            {
                var rows = GetRowsFromBody(body);
                foreach (var row in rows)
                {
                    var cells = GetCellsFromRow(row);
                    //Cells[0]  contains some shit. So "1" is the real first cell in the row
                    var name = GetCellNameFromCell(cells[1]);
                    //Values begin from number "2" and continue depends on count of comparing items
                    var value = GetCellValueFromCell(cells[index + 2]);
                    var color = GetCellColorFromCell(cells[index + 2]);
                    var pc = new ProductCharacteristic(name, value, color);
                    productCharacteristics.Add(pc);
                }
            }

            return productCharacteristics;
        }


        private string GetCellNameFromCell(IWebElement cell) => cell.GetAttribute("innerHTML");

        private string GetCellValueFromCell(IWebElement cell)
        {
            var value = GetCellSpanFromCell(cell).GetAttribute("innerHTML");
            if (value == "")
            {
                value = cell.Text;
            }
            if (value == "")
            {
                value = GetCellSpanFromCell(cell).GetAttribute("class").Split(" ").Last();
            }
            return value;
        }

        private string GetCellColorFromCell(IWebElement cell) =>
            cell.FindElement(By.XPath("ancestor::td")).GetCssValue("background-color");


        //usually all spans cells are inside other spans, but sometimes don't
        private IWebElement GetCellSpanFromCell(IWebElement cell)
        {
            try
            {
                return cell.FindElement(By.XPath("./span"));
            }
            catch (NoSuchElementException ex)
            {
                return cell;
            }
        }
    }
}