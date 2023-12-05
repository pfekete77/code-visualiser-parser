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
    public class TC03_MultipleParametersInPomMethodCall
    {
        protected readonly IWebDriver driver;

        [TestMethod]
        public void CreateNewAccount()
        {
            HomePage homePage = new HomePage(driver);

            LoginPage loginPage = new LoginPage(driver);
            homePage.NavigateToPage("username");
            
        }
    }
}
