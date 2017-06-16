using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomation.Pages
{
    public class AddBankAccountProcessPage
    {
        public static void Select_Bank()
        {
            IWebElement target_bank = Driver.Instance.FindElement(By.XPath("//div[@class='x-container ba-banklist xui-contentblock x-container-default']/ul/li[1]"));
            target_bank.Click();
        }

        public static void Enter_Account_Details()
        {
            var Account_Name_Field = Driver.Instance.FindElement(By.Id("accountname-1037-inputEl"));
            Random rng = new Random();

            Account_Name_Field.SendKeys("Kevin Liao " + rng.Next(1,101));

            IWebElement Account_Type_Field = Driver.Instance.FindElement(By.Id("accounttype-1039-inputEl"));
            Account_Type_Field.Click();
            Account_Type_Field.SendKeys(Keys.Tab);
            //Account_Type_Field.SendKeys("l");
            //var selectElement = new SelectElement(Account_Type_Field);
            //selectElement.SelectByValue("Loan");
            //selectElement.SelectByIndex(3);

            var Account_Number_Field = Driver.Instance.FindElement(By.Id("accountnumber-1068-inputEl"));
            Account_Number_Field.SendKeys("4987654321098769");
        }

        public static void Click_Continue_Button()
        {
            var Btn_Continue = Driver.Instance.FindElement(By.Id("common-button-submit-1015-btnInnerEl"));
            Btn_Continue.Click();
        }
    }
}
