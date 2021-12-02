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
            Assert.That(App.Pages.HomePage.IsLoaded, "Page is not loaded");
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