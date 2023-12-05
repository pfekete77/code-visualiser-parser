using CodeIntegratorPrototype.UI.Components;
using CodeIntegratorPrototype.UI.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Tests.AccountTests
{
    [TestClass]
    public class TC02_CreateNewAccount
    {
        protected readonly IWebDriver driver;

        private string accountType = "Person";
        private string username = "John Smith";
        private string email = "john.smith@fakeemail.com";

        [TestMethod]
        //[parameters=[{user=manager, can_see_result=true},
        //            {user=adviser1_team1, can_see_result=true},
        //            {user=adviser1_team2, can_see_result=false}]
        public void CreateNewAccount()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetUsername("username");
            loginPage.SetPassword("p@ssw0rd");
            loginPage.ClickLoginButton();

            HomePage homePage = new HomePage(driver);
            homePage.NavigateToPage("Accounts");

            AccountsPage accountsPage = new AccountsPage(driver);
            accountsPage.ClickNewAccountButton();

            NewAccountModal newAccountModal = new NewAccountModal(driver);
            newAccountModal.SelectAccountType(accountType);
            newAccountModal.EnterAccountName(username);
            newAccountModal.EnterEmailAddress(email);
            newAccountModal.ClickCreateButton();

            accountsPage = new AccountsPage(driver);
            accountsPage.OpenAccountRecord(username);

            AccountRecordPage accountRecordPage = new AccountRecordPage(driver);
            Assert.AreEqual(accountType, accountRecordPage.GetAccountType());
            Assert.AreEqual(username, accountRecordPage.GetUsername());
            Assert.AreEqual(email, accountRecordPage.GetEmail());
        }
    }
}
