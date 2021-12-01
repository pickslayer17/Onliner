using NUnit.Framework;

namespace Testing
{
    public class LoginPositiveTest : AbstractTest
    {
        [Test]
        public void Login()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            App.Pages.HomePage.WaitForPageLoad();
            
        }
    }
}