using System;
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
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            App = new AppLib(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}