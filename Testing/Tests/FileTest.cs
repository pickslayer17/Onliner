
using NUnit.Framework;

namespace Testing
{
    public class FileTest : AbstractTest
    {
        [Test]
        public void Upload()
        {
            App.Flow.GoTo("https://online-audio-converter.com/ru/");
            App.Pages.FileTestPage.UploadFile();
            App.Pages.FileTestPage.PressConvert();
            App.Pages.FileTestPage.DownloadFile("D:\\autoTestDownload");
        }
        
    }
}