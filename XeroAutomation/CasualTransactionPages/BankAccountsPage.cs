using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomation.Pages
{
    public class BankAccountsPage
    {
        public static void Click_Add_Bank_Account_Button()
        {
            //var Btn_AddBankAccount = Driver.Instance.FindElement(By.Id("ext-gen27"));
            var Btn_AddBankAccount = Driver.Instance.FindElement(By.CssSelector("[href*='/Banking/Account/#find']"));
            Btn_AddBankAccount.Click();
        }

        public static bool Suceess_Message_Is_Present()
        {
            var Success_Message = Driver.Instance.FindElement(By.Id("notify01"));
            Console.WriteLine(Success_Message.Text);
            return Success_Message.Displayed;
        }

    }
}
