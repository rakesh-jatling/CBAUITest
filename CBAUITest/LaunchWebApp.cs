using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static CBAUITest.Common_Const;

namespace CBAUITest
{
    class LaunchWebApp
    {
        private RemoteWebDriver driver;
        private RepLogger rep;

        private string cba_Url = "https://www.commbank.com.au";

        public RemoteWebDriver Launch()
        {
            rep = new RepLogger();

            rep.LogMessage(Status.Info, "Setting up WebDriver Capabilities", "");

            var options = new ChromeOptions();

            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("start-fullscreen");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("password_manager_enabled", false);

            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);

            rep.LogMessage(Status.Info, "Launching WebDriver", "");
           
            driver.Url = cba_Url;

            rep.LogMessage(Status.Info, "Navigate to URL : " + cba_Url, "");
            rep.LogMessage(Status.Info, "WebDriver Launched Successfully", "");

            return (RemoteWebDriver)driver;
        }

        public void Quit(RemoteWebDriver driver)
        {
            driver.Close();
            driver.Dispose();

            rep.LogMessage(Status.Info, "Quit Browser", "");
        }
    }
}
