using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomation
{

    public class XeroLoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://login.xero.com/");
        }

        public static void Login()
        {
            Input_Email_Address();
            Input_Password();
            Click_Login_Button();
        }

        public static void Input_Email_Address()
        {
            var EmailAddress = Driver.Instance.FindElement(By.Id("email"));
            EmailAddress.SendKeys("liaoyixiang@gmail.com");
        }

        public static void Input_Password()
        {
            var Password = Driver.Instance.FindElement(By.Id("password"));
            Password.SendKeys("xero2017");
        }

        public static void Click_Login_Button()
        {
            var btn_Login = Driver.Instance.FindElement(By.Id("submitButton"));
            btn_Login.Click();
        }
    }
}
