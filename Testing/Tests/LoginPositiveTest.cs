using NUnit.Framework;

namespace Testing
{
    public class LoginPositiveTest : AbstractTest
    {
        [Test]
        public void Login()
        {
            App.Flow.GoTo(TestSettings.HomeUrl);
            var user = TestSettings.UserName;
            var password = TestSettings.UserPassword;
            LoginUserPassword(user, password);
            var expectedUrl = TestSettings.HomeUrl;
            var currentUrl = App.Flow.GetCurrentUrl();
            Assert.That(expectedUrl == currentUrl);
        }

        private void LoginUserPassword(string name, string password)
        {
            App.Pages.HomePage.ClickEnterButton();
            App.Pages.LoginPage.FillEmail(name);
            App.Pages.LoginPage.FillPassword(password);
            App.Pages.LoginPage.ClickEnterButton();
        }
    }
}