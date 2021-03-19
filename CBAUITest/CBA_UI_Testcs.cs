using CBAUITest;
using CBAUITest.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace CBA_UI_Test
{
    class CBA_UI_Testcs
    {
        private LaunchWebApp WebApp;
        private RemoteWebDriver driver;
        private LoginPage loginPage;

        [SetUp]
        public void Init()
        {
            WebApp = new LaunchWebApp();

            driver = WebApp.Launch();

            loginPage = new LoginPage(driver);
        }

        [Test]
        public void FirstTest()
        {
            loginPage.IsLoginPageDisplayed();

            loginPage.CheckLogonButtonDisplayed();
        }

        [TearDown]
        public void Cleanup()
        {
            WebApp.Quit(driver);
        }
    }
}
