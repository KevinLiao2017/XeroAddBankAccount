using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XeroAutomation;
using XeroAutomation.Pages;

namespace XeroTests
{
    [TestClass]
    public class AddBankAccount
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Add_Bank_Accout()
        {
            XeroLoginPage.GoTo();
            XeroLoginPage.Login();
            DashboardPage.Click_Accounts_Menu();
            DashboardPage.Click_Bank_Accounts_SubMenu();
            BankAccountsPage.Click_Add_Bank_Account_Button();
            AddBankAccountProcessPage.Select_Bank();
            AddBankAccountProcessPage.Enter_Account_Details();
            AddBankAccountProcessPage.Click_Continue_Button();
            Assert.IsTrue(BankAccountsPage.Suceess_Message_Is_Present(), "Adding bank accout was NOT successful");
        }

        [TestCleanup]
        public void Cleanup()
        {
           Driver.Close();
        }
    }
}
