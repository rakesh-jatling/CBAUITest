using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using static CBAUITest.Common_Const;

namespace CBAUITest.Pages
{

    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly RepLogger rep;
        private readonly WebDriverWait wait;

        private By Logon_Button = By.XPath("//a/span[@class='login']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            rep = new RepLogger(driver);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void IsLoginPageDisplayed()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Logon_Button));

                rep.LogMessage(Status.Info, "Element visible : 'Login'", "", false);
            }
            catch (Exception e)
            {
                rep.LogMessage(Status.Fail, "Unable to find Element : 'Login'", "", true);
                throw e;
            }
        }

        public void CheckLogonButtonDisplayed()
        {
            Assert.AreEqual("Log on", driver.FindElement(Logon_Button).Text, "Logon Button Not Displayed");
        }
    }
}
