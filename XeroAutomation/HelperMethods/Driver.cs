using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;
using System.Drawing.Imaging;

namespace XeroAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            //Instance = new FirefoxDriver();

            //Remember to update the following directory to the correct location where the chromedriver.exe file locates. 
            Instance = new ChromeDriver(@"C:\AutomatedTests\XERO\XeroAutomation");

            
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(59));
            Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(59));
            Instance.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(59));
            Instance.Manage().Window.Maximize();
        }


        public static void Close()
        {
            Instance.Quit();
        }

        public static void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Instance;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void ChangeTimeSpan(int i)
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(i));
        }

        private static void TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            Instance.TakeScreenshot().SaveAsFile("Exception-" + timestamp + ".png", ImageFormat.Png);
        }
    }
}
