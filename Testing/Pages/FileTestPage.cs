using System;
using System.IO;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Testing.Extensions.WaitExtensions;

namespace Testing.Pages
{
    public class FileTestPage : AbstractPage
    {
        public FileTestPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _fileInput => _driver.FindElement(By.XPath("//input[@type='file']"));
        private string _fileName = "Metallica - Nothing Else Matters.mp3";
        private IWebElement _fileNameSpan => WaitAndGet(_driver, By.XPath("//span[@class='filename']"));

        private IWebElement _converterButton =>
            _driver.FindElement(By.XPath("//div[@id='converter']//div[@class='button_1_inner_2']"));

        private By _cancelButtonLocator = By.XPath(
            "//div[@class='padding']//div[@class='text']/following-sibling::div/div[@class='button_4_inner_1']");

        private IWebElement _cancelButton => _driver.FindElement(_cancelButtonLocator);
        private IWebElement _downloadLink => _driver.FindElement(By.XPath("//a[@id='download_file_link']"));

        public void UploadFile()
        {
            _fileInput.SendKeys(Path.GetFullPath(_fileName));
        }

        public void PressConvert()
        {
            if (_fileNameSpan.Text == _fileName)
                _converterButton.Click();
            Thread.Sleep(1000);
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(_cancelButton);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(ElementIsVisible);
        }

        public void DownloadFile(string path)
        {
            var link = _downloadLink.GetAttribute("href");
            var absolutePath = Path.Combine(path, "converted_" + _fileName);
            Directory.CreateDirectory(path);
            if (!File.Exists(absolutePath))
            using (File.Create(absolutePath));
            
            using (var client = new WebClient())
            client.DownloadFile(link, absolutePath);
            
        }
      
        private Func<IWebElement, bool> ElementIsVisible = (IWebElement element) =>
        {
            if (element.Displayed) return false;
            return true;
        };
    }
}