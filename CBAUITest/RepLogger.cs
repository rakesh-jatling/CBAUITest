using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static CBAUITest.Common_Const;

namespace CBAUITest
{
    public class RepLogger
    {
        private IWebDriver driver;

        public RepLogger() { }

        public RepLogger(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogMessage(Status LogStatus, string Title, string Message, bool IsTakeScreenShot = false)
        {
            string currTime = DateTime.Now.ToString("HH:mm:ss:fff");

            string msg = "[" + currTime + "] " + "[" + LogStatus + "] " + Title + Message;

            string txtFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Result_log.txt");
            using (StreamWriter sw = File.AppendText(txtFilePath))
            {
                sw.WriteLine(msg);

            }
        }
    }
}
