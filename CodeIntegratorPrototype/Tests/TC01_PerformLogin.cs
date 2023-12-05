using CodeIntegratorPrototype.UI.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace CodeIntegratorPrototype
{
    [TestClass]
    public class TC01_PerformLogin
    {
        protected readonly IWebDriver driver;

        [TestMethod]
        public void PerformLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetUsername("username");
            loginPage.SetPassword("p@ssw0rd");
            loginPage.ClickLoginButton();
        }
    }
}