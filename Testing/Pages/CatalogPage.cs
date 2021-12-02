using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Testing.Extensions;

namespace Testing.Pages
{
    public class CatalogPage : AbstractPage
    {
        private readonly string _listAsideTitlesXpath =
            "(//div[@class='catalog-navigation-list__wrapper']/div[@class='catalog-navigation-list__category']/div[contains(@class, 'catalog-navigation-list__aside')])[1]/div/div";

        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        public ElectronicsCategories CurrentCategory { get; private set; }

        private ReadOnlyCollection<IWebElement> _catalogItemTitles => WaitExtensions.WaitAndGetElements(_driver,
            By.XPath("//span[@class='catalog-navigation-classifier__item-title']"));


        private ReadOnlyCollection<IWebElement> _listAsideTitles => WaitExtensions.WaitAndGetElements(_driver,
            By.XPath(_listAsideTitlesXpath));

        private ReadOnlyCollection<IWebElement> _listDropDownTitleSpans => WaitExtensions.WaitAndGetElements(_driver,
            By.XPath(
                string.Format("{0}[{1}]/div[2]/div/a/span/span[2]", _listAsideTitlesXpath,
                    (int) CurrentCategory)
            )
        );

        public override bool IsLoaded() => _catalogItemTitles.Any();

        public void GoToTv()
        {
            ClickElectronics();
            ChooseElectronicsCategory(ElectronicsCategories.TvAndVideo);
            ClickTvs();
        }

        public void ClickElectronics() => _catalogItemTitles[0].Click();

        public void ChooseElectronicsCategory(ElectronicsCategories category)
        {
            _listAsideTitles[(int) category - 1].Click();
            CurrentCategory = category;
        }

        public void ClickTvs() => _listDropDownTitleSpans[0].Click();
    }

    public enum ElectronicsCategories
    {
        MobilePhoneAndAccessories = 1,
        TvAndVideo = 2
    }
}