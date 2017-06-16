using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomation.Pages
{
    public class DashboardPage
    {
        public static void Click_Accounts_Menu()
        {
            var Menu_Accounts = Driver.Instance.FindElement(By.Id("Accounts"));
            Menu_Accounts.Click();
        }

        public static void Click_Bank_Accounts_SubMenu()
        {
            var Menu_BankAccounts = Driver.Instance.FindElement(By.XPath("//*[@id='xero-nav']/div[2]/div[2]/div[1]/ul/li[2]/ul/li[1]/a"));
            Menu_BankAccounts.Click();
        }
    }
}
