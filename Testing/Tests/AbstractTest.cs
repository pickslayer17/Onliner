using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Testing.Lib;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

[assembly: Parallelizable(ParallelScope.All)]

namespace Testing
{
    public abstract class AbstractTest : IDisposable
    {
        private IWebDriver _driver;
        public AppLib App { get; private set; }

        public void Dispose()
        {
            _driver.Quit();
        }

        [SetUp]
        public void Setup()
        {
            IDriverConfig driverConfig = new ChromeConfig();
            new DriverManager().SetUpDriver(driverConfig, VersionResolveStrategy.MatchingBrowser);
            ChromeOptions co = new ChromeOptions();
            co.AddArguments("--no-sandbox");
            // co.AddArgument("headless");
            // co.AddArguments("enable-automation");
            // co.AddArguments("--disable-infobars");
            // co.AddArguments("--disable-dev-shm-usage");
            // co.AddArguments("--disable-browser-side-navigation");
            co.AddArguments("--disable-gpu");
            _driver = new ChromeDriver(co);
            _driver.Manage().Window.Maximize();
            App = new AppLib(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
        protected void LoginUserPassword(string name, string password)
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.ClickEnterButton();
            App.Pages.LoginPage.FillEmail(name);
            App.Pages.LoginPage.FillPassword(password);
            App.Pages.LoginPage.ClickEnterButton();
        }
    }
}